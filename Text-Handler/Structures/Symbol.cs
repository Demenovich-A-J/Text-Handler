using System;

namespace Text_Handler.Structures
{
    public struct Symbol
    {
        private char _chars;

        public char Chars
        {
            get { return _chars; }
            set { _chars = value; }
        }

        public Symbol(char chars)
        {
            this._chars = chars;
        }
    }
}