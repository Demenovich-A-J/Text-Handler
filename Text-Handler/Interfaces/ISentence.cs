using System;
using System.Collections.Generic;

namespace Text_Handler.Interfaces
{
    public interface ISentence
    {
        IList<ISentenceItem> Items { get; }
        bool IsInterrogative { get; }
        ISentence RemoveWordsBy(Func<IWord, bool> predicate);
        IEnumerable<ISentenceItem> ReplaceWordByElements(Func<IWord, bool> predicate, IList<ISentenceItem> items);
        IEnumerable<IWord> GetWordsWithoutRepetition(int length);
        string SentenceToString();
    }
}