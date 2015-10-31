using System.Linq;
using System.Text;
using Text_Handler.Interfaces;
using Text_Handler.Structures;

namespace Text_Handler.TextObjects
{
    public class Digit : IDigit
    {
        public Digit(string chars)
        {
            Symbols = chars != null ? chars.Select(x => new Symbol(x)).ToArray() : null;
        }

        public string Chars
        {
            get
            {
                var sb = new StringBuilder();

                foreach (var symbol in Symbols)
                {
                    sb.Append(symbol.Chars);
                }

                return sb.ToString();
            }
        }

        public Symbol[] Symbols { get; private set; }

        public Symbol this[int index]
        {
            get { return Symbols[index]; }
        }

        public int Length
        {
            get { return Symbols.Length; }
        }
    }
}