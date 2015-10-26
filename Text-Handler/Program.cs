using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Text_Handler
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new TextParser(new SeparatorContainer());

            var c = a.Parse(new StreamReader("1.txt", Encoding.Default));

            var d = c.GetInterrogativeSentences().ToList();

            Console.ReadKey();
        }
    }
}
