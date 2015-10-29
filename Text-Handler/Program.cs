using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Text_Handler.Interfaces;
using Text_Handler.Parser;
using Text_Handler.TextObjects;

namespace Text_Handler
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new TextParser();

            var c = a.Parse(new StreamReader("1.txt", Encoding.Default));

            c.ReplaceWordInSentence(0, 6, a.ParseSentence("привет, красавчик").Items.ToList());

            //var d = c.GetSentencesWithoutConsonants(6).ToList().ToList();

            Console.WriteLine(c);

            Console.ReadKey();
        }
    }
}