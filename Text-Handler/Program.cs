using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Text_Handler.Parser;

namespace Text_Handler
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new TextParser();

            var c = a.Parse(new StreamReader("1.txt", Encoding.Default));

            var d = c.GetSentencesWithoutConsonants(6).ToList().ToList();

            Console.WriteLine(c);

            Console.ReadKey();
        }
    }
}