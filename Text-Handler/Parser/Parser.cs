using System.IO;

namespace Text_Handler.Parser
{
    public abstract class Parser
    {
        public abstract Text Parse(StreamReader fileReader);
    }
}