using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Text_Handler.Interfaces;
using Text_Handler.TextObjects;

namespace Text_Handler
{
    public class TextParser : Parser
    {
        private readonly SeparatorContainer _separators;
        private readonly Regex _lineTosentenceRegex = new Regex(@"(?<=[\.*!\?])\s+(?=[А-Я]|[A-Z])|(?=\W&([А-Я]|[A-Z]))", RegexOptions.Compiled);
        private readonly Regex _sentenceToWordsRegex = new Regex(@"(\W*)([A-z]*|[А-я]*)(\W)", RegexOptions.Compiled);

        public TextParser(SeparatorContainer separators)
        {
            this._separators = separators;
        }

        public override Text Parse(StreamReader fileReader)
        {
            Text textResult = new Text();

            try
            {
                var sentenceSeparators = _separators.GetSentenceSeparator();

                string line;
                string buffer = null;

                while ((line = fileReader.ReadLine()) != null)
                {
                    line = buffer + line;

                    var sentences = _lineTosentenceRegex.Split(line).Select(x => Regex.Replace(x.Trim(), @"\s+", @" ")).ToArray();

                    if (!sentenceSeparators.Contains(sentences.Last().Last().ToString()))
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

        private ISentence ParseSentence(string sentence)
        {
            var result = new Sentence();

            foreach (Match match in _sentenceToWordsRegex.Matches(sentence))
            {
                if (match.Groups[1].Value != "" && match.Groups[1].Value != " ")
                {
                    result.Items.Add(new Punctuation(match.Groups[1].Value));
                }
                if (match.Groups[2].Value != "" && match.Groups[2].Value != " ")
                {
                    result.Items.Add(new Word(match.Groups[2].Value));
                }
                if (match.Groups[3].Value != "" && match.Groups[3].Value != " ")
                {
                    result.Items.Add(new Punctuation(match.Groups[3].Value));
                }
            } 

            return result;
        }
    }
}