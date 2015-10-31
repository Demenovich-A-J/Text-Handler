using Text_Handler.Structures;

namespace Text_Handler.Interfaces
{
    public interface IDigit : ISentenceItem
    {
        Symbol[] Symbols { get; }
        Symbol this[int index] { get; }
        int Length { get; }
    }
}