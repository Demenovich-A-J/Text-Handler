namespace Text_Handler.Separators
{
    public static class DigitSeparator
    {
        private static readonly string[] _arabicDigits = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};

        public static string[] ArabicDigits
        {
            get { return _arabicDigits; }
        }
    }
}