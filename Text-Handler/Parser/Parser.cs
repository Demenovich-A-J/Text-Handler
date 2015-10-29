using System.IO;
using Text_Handler.Interfaces;

namespace Text_Handler.Parser
{
    public abstract class Parser
    {
        public abstract Text Parse(StreamReader fileReader);
        public abstract ISentence ParseSentence(string sentence);
    }
}