namespace Text_Handler.Separators
{
    public static class VolwesSeparator
    {
        private static readonly string[] _russianVolwesSeparator = {"а", "у", "о", "ы", "и", "э", "я", "ю", "ё", "е"};

        public static string[] RussianVolwesSeparator
        {
            get { return _russianVolwesSeparator; }
        }
    }
}