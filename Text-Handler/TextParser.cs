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
        private SeparatorContainer separators;
        private Regex lineTosentenceRegex = new Regex(@"(?<=[\.!\?])\s+", RegexOptions.Compiled);

        public TextParser(SeparatorContainer separators)
        {
            this.separators = separators;
        }

        public override Text Parse()
        {
            try
            {
                var sentenceSeparators = separators.GetSentenceSeparator();
                Text textResult = new Text();
                string line;
                string buffer = null;
                
                var fileReader = new StreamReader(@"1.txt", Encoding.Default);


                while ((line = fileReader.ReadLine()) != null)
                {
                    line = buffer + line;

                    var str = lineTosentenceRegex.Split(line);

                    if (!sentenceSeparators.Contains(str.Last().Last().ToString()))
                    {
                        buffer = str.Last();
                        textResult.Sentences.AddRange(str.Select(x => x).Where(x => x != str.Last()).Select(parseSentence));
                    }
                    else
                    {
                        textResult.Sentences.AddRange(str.Select(parseSentence));
                        buffer = null;
                    }
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Data.ToString());
            }

            return null;

        }

        private ISentence parseSentence(string sentence)
        {
            var res = new Sentence();

            res.Items.Add(new Word(sentence));

            return res;
        }
    }
}