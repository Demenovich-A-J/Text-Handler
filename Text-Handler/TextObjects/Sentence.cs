using System.Collections.Generic;
using System.Linq;
using Text_Handler.Interfaces;

namespace Text_Handler.TextObjects
{
    public class Sentence : ISentence
    {
        public ICollection<ISentenceItem> Items { get; private set; }

        public bool IsInterrogative()
        {
            return Items.Last().Chars == "?";
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