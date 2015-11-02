using System.Linq;
using System.Text;
using Text_Handler.Interfaces;
using Text_Handler.Structures;

namespace Text_Handler.TextObjects
{
    public class Punctuation : IPunctuation
    {
        public Punctuation(string chars)
        {
            Symbols = new Symbol(chars);
        }

        public string Chars => Symbols.Chars;

        public Symbol Symbols { get; }

    }
}