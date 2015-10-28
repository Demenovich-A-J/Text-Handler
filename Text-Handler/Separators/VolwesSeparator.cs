using Text_Handler.Interfaces;

namespace Text_Handler.Separators
{
    public static class VolwesSeparator
    {
        private static readonly string[] _separator = { "а", "у", "о","ы", "и", "э", "я", "ю", "ё", "е" };
        public static string[] Separator
        {
            get { return _separator; }
        }
    }
}