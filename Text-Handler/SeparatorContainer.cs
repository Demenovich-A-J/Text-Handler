using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Text_Handler
{
    public class SeparatorContainer
    {
        private string[] sentenceSeparator = new[] {".", "!", "?"};

        public string[] GetSentenceSeparator()
        {
            return sentenceSeparator;
        } 
    }
}