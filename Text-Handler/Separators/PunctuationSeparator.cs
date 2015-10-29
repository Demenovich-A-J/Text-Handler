namespace Text_Handler.Separators
{
    public static class PunctuationSeparator
    {
        private static readonly string[] _sentencePunctuationSeparator = {".", "!", "?"};
        private static readonly string[] _sentenceNoWhiteSpacePunctuation = { "—" , ")" };
        private static readonly string[] _doubleSentencePunctuationSeparator = {"\"", "'" , "(" , "<"};
        public static string[] SentencePunctuationSeparator
        {
            get { return _sentencePunctuationSeparator; }
        }

        public static string[] DoubleSentencePunctuationSeparator
        {
            get { return _doubleSentencePunctuationSeparator; }
        }

        public static string[] SentenceNoWhiteSpacePunctuation
        {
            get { return _sentenceNoWhiteSpacePunctuation; }
        }
    }
}