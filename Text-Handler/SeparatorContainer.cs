using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Text_Handler
{
    public class SeparatorContainer
    {
        private readonly string[] _sentenceSeparator = {".", "!", "?"};
        private static readonly string[] _vowelsSeparator = {""};

        public string[] GetSentenceSeparator()
        {
            return _sentenceSeparator;
        }

        public static string[] GetVowelsSeparator()
        {
            return _vowelsSeparator;
        } 
    }
}