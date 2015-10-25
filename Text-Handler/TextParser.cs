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

                    var sentences = _lineTosentenceRegex.Split(line);

                    if (!sentenceSeparators.Contains(sentences.Last().Last().ToString()))
                    {
                        buffer = sentences.Last();
                        textResult.Sentences.AddRange(
                            sentences.Select(x => x).Where(x => x != sentences.Last()).Select(parseSentence));
                    }
                    else
                    {
                        textResult.Sentences.AddRange(sentences.Select(parseSentence));
                        buffer = null;
                    }
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Data.ToString());
            }
            finally
            {
                fileReader.Close();
                fileReader.Dispose();
            }

            return textResult;

        }

        private ISentence parseSentence(string sentence)
        {
            var res = new Sentence();

            res.Items.Add(new Word(sentence));

            return res;
        }
    }
}