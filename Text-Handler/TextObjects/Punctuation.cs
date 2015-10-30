using Text_Handler.Interfaces;
using Text_Handler.Structures;

namespace Text_Handler.TextObjects
{
    public class Punctuation : IPunctuation
    {
        private Symbol _value;
        public string Chars
        {
            get { return _value.Chars.ToString(); }
        }
        public Symbol Value
        {
            get { return this._value; }
        }

        public Punctuation(char chars)
        {
            _value = new Symbol(chars);
        }
    }
}