using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Text_Handler.Helpers;
using Text_Handler.Interfaces;
using Text_Handler.Separators;
using Text_Handler.TextObjects;

namespace Text_Handler.Parser
{
    public class TextParser : Parser
    {
        private readonly Regex _lineTosentenceRegex = new Regex(
            @"(?<=[\.*!\?])\s+(?=[А-Я]|[A-Z])|(?=\W&([А-Я]|[A-Z]))", RegexOptions.Compiled);

        private readonly Regex _sentenceToWordsRegex =
            new Regex(
                @"(\W*)(\w+[\-|`]\w+)(\!\=|\>\=|\=\<|\/|\=\=|\?\!|\!\?|\.{3}|\W)|(\W*)(\w+|\d+)(\!\=|\>\=|\=\<|\/|\=\=|\?\!|\!\?|\.{3}|\W)|(.*)",
                RegexOptions.Compiled);


        public override Text Parse(StreamReader fileReader)
        {
            var textResult = new Text();

            try
            {
                string line;
                string buffer = null;

                while ((line = fileReader.ReadLine()) != null)
                {
                    if (Regex.Replace(line.Trim(), @"\s+", @" ") != "")
                    {
                        line = buffer + line;

                        var sentences =
                            _lineTosentenceRegex.Split(line)
                                .Select(x => Regex.Replace(x.Trim(), @"\s+", @" "))
                                .ToArray();

                        if (
                            !PunctuationSeparator.EndPunctuationSeparator.Contains(
                                sentences.Last().Last().ToString()))
                        {
                            buffer = sentences.Last();
                            textResult.Sentences.AddRange(
                                sentences.Select(x => x).Where(x => x != sentences.Last()).Select(ParseSentence));
                        }
                        else
                        {
                            textResult.Sentences.AddRange(sentences.Select(ParseSentence));
                            buffer = null;
                        }
                    }
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Data.ToString());
                fileReader.Close();
            }
            finally
            {
                fileReader.Close();
                fileReader.Dispose();
            }

            return textResult;
        }

        public override ISentence ParseSentence(string sentence)
        {
            var result = new Sentence();

            Func<string, ISentenceItem> toISentenceItem =
                item =>
                    (!PunctuationSeparator.AllSentenceSeparators.Contains(item) &&
                     !DigitSeparator.ArabicDigits.Contains(item[0].ToString()))
                        ? (ISentenceItem) new Word(item)
                        : (DigitSeparator.ArabicDigits.Contains(item[0].ToString()))
                            ? (ISentenceItem) new Digit(item)
                            : new Punctuation(item);

            foreach (Match match in _sentenceToWordsRegex.Matches(sentence))
            {
                for (var i = 1; i < match.Groups.Count; i++)
                {
                    if (match.Groups[i].Value.Trim() != "")
                    {
                        result.Items.Add(toISentenceItem(match.Groups[i].Value.Trim()));
                    }
                }
            }

            return result;
        }
    }
}