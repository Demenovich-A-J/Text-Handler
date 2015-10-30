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


        private StringBuilder _sb = new StringBuilder();
        private int _i;
        private void GlueWords(int index)
        {
            _i = index;
            while (true)
            {
                _i++;
                if (_i >= Items.Count) break;
                _sb.Append(Items[_i].Chars);
                var nextElement = Items.ElementAtOrDefault(_i + 1);
                if (nextElement != null)
                {
                    if (!PunctuationSeparator.EndPunctuationSeparator.Contains(Items[_i].Chars) &&
                        !PunctuationSeparator.ClosePunctuationSeparator.Contains(nextElement.Chars) &&
                        !PunctuationSeparator.InnerPunctuationSeparator.Contains(nextElement.Chars) &&
                        !PunctuationSeparator.EndPunctuationSeparator.Contains(nextElement.Chars))
                    {
                        if (PunctuationSeparator.ClosePunctuationSeparator.Contains(Items[_i].Chars))
                        {
                            break;
                        }
                        if (PunctuationSeparator.OpenPunctuationSeparator.Contains(Items[_i].Chars) ||
                            PunctuationSeparator.RepeatPunctuationSeparator.Contains(Items[_i].Chars))
                        {
                            GlueWords(_i);
                        }

                        if (!PunctuationSeparator.ClosePunctuationSeparator.Contains(nextElement.Chars))
                        {
                            _sb.Append(" ");
                        }
                    }
                }
            }
        }

        public string SentenceToString()
        {
            GlueWords(-1);
            return _sb.ToString();
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
    }
}