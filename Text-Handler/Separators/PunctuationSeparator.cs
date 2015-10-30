// ReSharper disable All
namespace Text_Handler.Separators
{
    public static class PunctuationSeparator
    {
        private static readonly string[] _repeatPunctuationSeparator = {"\"", "'"};
        private static readonly string[] _endPunctuationSeparator = {"!", ".", "?"};
        private static readonly string[] _innerPunctuationSeparator = { ",", ".", ";", ":"};
        private static readonly string[] _openPunctuationSeparator = {"<", "(", "[", "{", "„", "«", "‘"};
        private static readonly string[] _closePunctuationSeparator = {")", ">", "]", "}", "“", "»", "’"};
        private static readonly string[] _allSentenceSeparators =
        {
            ",", ".", "!", "?", "—", "-", "\"", "'", "(", ")",
            "<", ">", ":", ";", "[", "]", "{", "}", "‒", "–", "—", 
            "―", "„", "“", "«", "»", "‘", "’"
        };

        public static string[] AllSentenceSeparators
        {
            get { return _allSentenceSeparators; }
        }

        public static string[] RepeatPunctuationSeparator
        {
            get { return _repeatPunctuationSeparator; }
        }

        public static string[] EndPunctuationSeparator
        {
            get { return _endPunctuationSeparator; }
        }

        public static string[] InnerPunctuationSeparator
        {
            get { return _innerPunctuationSeparator; }
        }

        public static string[] OpenPunctuationSeparator
        {
            get { return _openPunctuationSeparator; }
        }

        public static string[] ClosePunctuationSeparator
        {
            get { return _closePunctuationSeparator; }
        }
    }
}