using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_Handler.Interfaces;
using Text_Handler.TextObjects;

namespace Text_Handler
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = new Word("hello");
            var a = new Sentence(new List<ISenteceItem>()
            {
                new Word("Hi"),
                new Punctuation(","),
                new Word("i"),
                new Punctuation("`"),
                new Word("am"),
                new Word("Artur"),
                new Punctuation(".")
            });

            var text = new Text();

            text.Sentences.Add(a);

            foreach (var v in text.Sentences)
            {
                foreach (var c in v.Items)
                {
                    Console.Write(c.Chars);
                }
            }

            Console.ReadKey();

        }
    }
}
