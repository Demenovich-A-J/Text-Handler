using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Text_Handler
{
    public class SeparatorContainer
    {
        private readonly string[] _sentenceSeparator = {".", "!", "?"};

        public string[] GetSentenceSeparator()
        {
            return _sentenceSeparator;
        } 
    }
}