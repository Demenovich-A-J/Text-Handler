using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_Handler.TextObjects;

namespace Text_Handler
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = new Word("hello");

            Console.WriteLine(word[0].Chars);

            Console.ReadKey();

        }
    }
}
