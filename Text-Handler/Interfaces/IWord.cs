using Text_Handler.Structures;

namespace Text_Handler.Interfaces
{
    public interface IWord : ISentenceItem
    {
        Symbol[] Symbols { get; }
        Symbol this[int index] { get; }
        int Length { get; }
        bool IsСonsonant(string[] vowels);
    }
}