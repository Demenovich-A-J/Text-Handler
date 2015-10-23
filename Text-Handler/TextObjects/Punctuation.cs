using Text_Handler.Interfaces;
using Text_Handler.Structures;

namespace Text_Handler.TextObjects
{
    public class Punctuation : IPunctuation
    {
        private Symbol _value;
        public string Chars
        {
            get { return _value.Chars; }
        }
        public Symbol Value
        {
            get { return this._value; }
        }

        public Punctuation(string chars)
        {
            _value = new Symbol(chars);
        }
    }
}