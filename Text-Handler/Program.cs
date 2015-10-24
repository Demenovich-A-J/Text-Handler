using System;
using System.Collections;
using System.Collections.Generic;
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

            a.Parse();
            Console.ReadKey();

        }
    }
}
