using System.Collections.Generic;

namespace Text_Handler.Interfaces
{
    public interface ISentence
    {
        IList<ISentenceItem> Items { get; }
        bool IsInterrogative();
        IEnumerable<ISentenceItem> RemoveConsonantsWords(int length);
        IEnumerable<ISentenceItem> ReplaceWordByElements(int length, IList<ISentenceItem> items);
    }
}