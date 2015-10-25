using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Text_Handler.Interfaces;
using Text_Handler.TextObjects;

namespace Text_Handler
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new TextParser(new SeparatorContainer());

            var c = a.Parse(new StreamReader("1.txt", Encoding.Default));

            Console.ReadKey();
        }
    }
}
