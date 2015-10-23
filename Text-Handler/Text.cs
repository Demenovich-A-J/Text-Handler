using System.Collections.Generic;
using Text_Handler.Interfaces;

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

    }
}