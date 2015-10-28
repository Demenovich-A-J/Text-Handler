using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Text_Handler.Interfaces;
using Text_Handler.TextObjects;

namespace Text_Handler
{
    public class Text
    {
        public ICollection<ISentence> Sentences { get; set; }

        public Text()
        {
            Sentences = new List<ISentence>();
        }

        public Text(IEnumerable<ISentence> sentences) : this()
        {
            foreach (var sentence in sentences)
            {
                Sentences.Add(sentence);
            }
        }

        public IEnumerable<ISentence> SentencesInAscendingOrder()
        {
            return Sentences.OrderBy(x => x.Items.Count);
        }

        public IEnumerable<ISentence> GetInterrogativeSentences()
        {
            return Sentences.Where(x => x.IsInterrogative());
        }

        public IEnumerable<ISentence> GetSentencesСonsonant(int length)
        {
            foreach (var v in Sentences)
            {
                foreach (var c in v.Items)
                {
                    var d = c as Word;
                    if (d != null && d.IsСonsonant(SeparatorContainer.GetVowelsSeparator()))
                    {
                        v.Items.Remove(c);
                    }
                    
                }
            }

            return null;
        }
    }
}