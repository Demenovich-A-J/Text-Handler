using System;

namespace Text_Handler.Structures
{
    public struct Symbol
    {
        private string _chars;

        public string Chars
        {
            get { return _chars; }
            set { _chars = value; }
        }

        public Symbol(string chars)
        {
            this._chars = chars;
        }

        public Symbol(char item)
        {
            this._chars = String.Format("{0}",item);
        }

    }
}