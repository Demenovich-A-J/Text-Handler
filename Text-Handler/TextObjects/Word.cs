using System.Linq;
using System.Text;
using Text_Handler.Interfaces;
using Text_Handler.Structures;

namespace Text_Handler.TextObjects
{
    public class Word : IWord
    {
        public Word(string chars)
        {
            this.Symbols = chars != null ? chars.Select(x => new Symbol(x)).ToArray() : null;
            this.Length = Symbols.Length != null ? Symbols.Length : 0;
        }

        public string Chars
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                foreach (var symbol in Symbols)
                {
                    sb.Append(symbol);
                }

                return sb.ToString();
            }
        }

        public Symbol[] Symbols { get; private set; }

        public Symbol this[int index]
        {
            get { return this.Symbols[index]; }
        }

        public int Length { get; private set; }
    }
}