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
            _chars = chars;
        }

        public Symbol(char source)
        {
            _chars = string.Format("{0}", source);
        }
    }
}