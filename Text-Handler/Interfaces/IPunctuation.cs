using Text_Handler.Structures;

namespace Text_Handler.Interfaces
{
    public interface IPunctuation : ISenteceItem
    {
        Symbol Value { get; }
    }
}