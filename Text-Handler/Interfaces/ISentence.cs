using System.Collections.Generic;

namespace Text_Handler.Interfaces
{
    public interface ISentence
    {
        ICollection<ISenteceItem> Items { get; }
    }
}