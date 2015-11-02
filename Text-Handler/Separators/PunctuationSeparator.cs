namespace Text_Handler.Separators
{
    public static class PunctuationSeparator
    {
        public static string[] RepeatPunctuationSeparator { get; } = {"\"", "'"};

        public static string[] EndPunctuationSeparator { get; } = {"!", ".", "?", "...", "?!", "!?"};

        public static string[] InnerPunctuationSeparator { get; } = {",", ";", ":"};

        public static string[] OpenPunctuationSeparator { get; } = {"<", "(", "[", "{", "„", "«", "‘"};

        public static string[] ClosePunctuationSeparator { get; } = {")", ">", "]", "}", "“", "»", "’"};

        public static string[] AllSentenceSeparators { get; } = {
            ",", ".", "!", "?", "—", "-", "\"", "'", "(", ")",
            "<", ">", ":", ";", "[", "]", "{", "}", "‒", "–", "—",
            "―", "„", "“", "«", "»", "‘", "’", "...", "?!", "!?", "*", "/", "=", "==", "!=", ">=", "=<", "+"
        };

        public static string[] OperationPunctuationSeparator { get; } = {"*", "/", "+", "=", "==", "!=", ">=", "=<"};
    }
}