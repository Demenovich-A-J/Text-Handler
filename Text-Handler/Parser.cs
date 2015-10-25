using System.Collections.Generic;
using System.IO;

namespace Text_Handler
{
    public abstract class Parser
    {
        public abstract Text Parse(StreamReader fileReader);
    }
}