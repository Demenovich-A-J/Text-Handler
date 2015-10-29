using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Text_Handler.Interfaces;
using Text_Handler.Separators;

namespace Text_Handler.TextObjects
{
    public class Sentence : ISentence
    {
        public IList<ISentenceItem> Items { get; private set; }

        public bool IsInterrogative()
        {
            return Items.Last().Chars == "?";
        }

        public IEnumerable<ISentenceItem> RemoveConsonantsWords(int length)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                var word = Items[i] as Word;
                if (word != null && word.IsСonsonant(VolwesSeparator.Separator) && word.Length == length)
                {
                    Items.RemoveAt(i);
                }
            }

            return Items;
        }

        public IEnumerable<ISentenceItem> ReplaceWordByElements(int length, IList<ISentenceItem> items)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Chars.Length != length) continue;

                Items.RemoveAt(i);

                foreach (var item in items)
                {
                    Items.Insert(i, item);
                    i++;
                }
            }

            return Items;
        }

        public Sentence()
        {
            Items = new List<ISentenceItem>();
        }

        public Sentence(IEnumerable<ISentenceItem> items) :this()
        {
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        //TODO rework algorithm, remove ovrride and add method SentenceToString();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Items.Count; i++)
            {
                sb.Append(Items[i].Chars);

                var nextElement = Items.ElementAtOrDefault(i + 1);

                if (nextElement != null 
                    && (!PunctuationSeparator.SentencePunctuationSeparator.Contains(Items[i].Chars) 
                    && !PunctuationSeparator.SentenceNoWhiteSpacePunctuation.Contains(Items[i].Chars)
                    && nextElement.Chars != ","
                    && nextElement.Chars != ":"
                    && nextElement.Chars != ">"
                    && !PunctuationSeparator.SentencePunctuationSeparator.Contains(nextElement.Chars)
                    && !PunctuationSeparator.SentenceNoWhiteSpacePunctuation.Contains(nextElement.Chars)))
                {

                    if (PunctuationSeparator.DoubleSentencePunctuationSeparator.Contains(Items[i].Chars))
                    {
                        while (true)
                        {
                            i++;
                            if(i == Items.Count) break;
                            sb.Append(Items[i].Chars);
                            nextElement = Items.ElementAtOrDefault(i + 1);

                            if (PunctuationSeparator.DoubleSentencePunctuationSeparator.Contains(Items[i].Chars) || Items[i].Chars == ")")
                            {
                                break;
                            }


                            if (nextElement != null
                                && (!PunctuationSeparator.SentencePunctuationSeparator.Contains(Items[i].Chars)
                                    && !PunctuationSeparator.SentenceNoWhiteSpacePunctuation.Contains(Items[i].Chars)
                                    && nextElement.Chars != ","
                                    && nextElement.Chars != ":"
                                    && nextElement.Chars != ">"
                                    && !PunctuationSeparator.SentencePunctuationSeparator.Contains(nextElement.Chars)
                                    && !PunctuationSeparator.SentenceNoWhiteSpacePunctuation.Contains(nextElement.Chars)
                                    && !PunctuationSeparator.DoubleSentencePunctuationSeparator.Contains(nextElement.Chars)
                                    && nextElement.Chars != ")"))
                            {
                                sb.Append(" ");
                            }
                        }
                        if (i == Items.Count) break;
                        if(!PunctuationSeparator.DoubleSentencePunctuationSeparator.Contains(Items[i].Chars))
                            continue;
                    }
                    sb.Append(" ");
                }
            }

            sb.Append("\n");

            return sb.ToString();
        }
    }
}