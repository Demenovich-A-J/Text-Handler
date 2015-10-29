using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Text_Handler.Interfaces;
using Text_Handler.Separators;
using Text_Handler.TextObjects;

namespace Text_Handler.Parser
{
    public class TextParser : Parser
    {
        private readonly Regex _lineTosentenceRegex = new Regex(@"(?<=[\.*!\?])\s+(?=[А-Я]|[A-Z])|(?=\W&([А-Я]|[A-Z]))", RegexOptions.Compiled);
        private readonly Regex _sentenceToWordsRegex = new Regex(@"(\W*)(\w+\-\w+)(\W)|(\W*)(\w+)(\W)|(.*)", RegexOptions.Compiled);

        public override Text Parse(StreamReader fileReader)
        {
            Text textResult = new Text();

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
                            !PunctuationSeparator.SentencePunctuationSeparator.Contains(
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

        protected virtual ISentence ParseSentence(string sentence)
        {
            var result = new Sentence();

            foreach (Match match in _sentenceToWordsRegex.Matches(sentence))
            {
                if (match.Groups[1].Value.Trim() != "")
                {
                    result.Items.Add(new Punctuation(match.Groups[1].Value.Trim()));
                }
                if (match.Groups[2].Value.Trim() != "")
                {
                    result.Items.Add(new Word(match.Groups[2].Value.Trim()));
                }
                if (match.Groups[3].Value.Trim() != "")
                {
                    result.Items.Add(new Punctuation(match.Groups[3].Value.Trim()));
                }
                if (match.Groups[4].Value.Trim() != "")
                {
                    result.Items.Add(new Punctuation(match.Groups[4].Value.Trim()));
                }
                if (match.Groups[5].Value.Trim() != "")
                {
                    result.Items.Add(new Word(match.Groups[5].Value.Trim()));
                }
                if (match.Groups[6].Value.Trim() != "")
                {
                    result.Items.Add(new Punctuation(match.Groups[6].Value.Trim()));
                }
                if (match.Groups[7].Value.Trim() != "")
                {
                    result.Items.Add(new Punctuation(match.Groups[7].Value.Trim()));
                }
            }

            return result;
        }
    }
}