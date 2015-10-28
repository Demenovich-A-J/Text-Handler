using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public IEnumerable<IEnumerable<ISentenceItem>> GetSentencesWithoutConsonants(int length)
        {
            return Sentences.Select( x => x.RemoveConsonantsWords(length));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var sentence in Sentences)
            {
                sb.Append(sentence + "\n");
            }

            return sb.ToString();
        }
    }
}