using Text_Handler.Structures;

namespace Text_Handler.Interfaces
{
    public interface IPunctuation : ISentenceItem
    {
        Symbol Symbols { get; }
    }
}