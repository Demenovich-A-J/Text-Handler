using System;
using System.Collections.Generic;
using Text_Handler.Interfaces;

namespace Text_Handler
{
    public static class CollectionHelper
    {
        public static void AddRange<T>(this ICollection<T> destination,
           IEnumerable<T> source)
        {
            foreach (T item in source)
            {
                destination.Add(item);
            }
        }
    }
}