using System.Collections.Generic;
using Text_Handler.Interfaces;

namespace Text_Handler.TextObjects
{
    public class Sentence : ISentence
    {
        public ICollection<ISenteceItem> Items { get; private set; }

        public Sentence()
        {
            Items = new List<ISenteceItem>();
        }

        public Sentence(IEnumerable<ISenteceItem> items) :this()
        {
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}