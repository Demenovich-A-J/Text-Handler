﻿using Text_Handler.Structures;

namespace Text_Handler.Interfaces
{
    public interface IWord : ISenteceItem
    {
        Symbol[] Symbols { get; }
        Symbol this[int index] { get; }
        int Length { get; }
    }
}