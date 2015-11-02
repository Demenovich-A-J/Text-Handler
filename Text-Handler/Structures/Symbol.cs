namespace Text_Handler.Structures
{
    public struct Symbol
    {
        public string Chars { get; set; }

        public Symbol(string chars)
        {
            Chars = chars;
        }

        public Symbol(char source)
        {
            Chars = $"{source}";
        }
    }
}