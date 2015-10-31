using System;
using System.IO;
using System.Linq;
using System.Text;
using Text_Handler.Parser;

namespace Text_Handler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var line = "||============================================================||";
            var parser = new TextParser();
            var streamReader = new StreamReader(@"..\..\Files\Text.txt", Encoding.Default);
            var text = parser.Parse(streamReader);

            //1 Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них.
            foreach (var sentence in text.GetSentencesInAscendingOrder())
            {
                Console.WriteLine(sentence.SentenceToString());
            }
            Console.WriteLine(line);

            //2 Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины.
            foreach (var word in text.GetWordsFromInterrogativeSentences(3))
            {
                Console.WriteLine(word.Chars);
            }
            Console.WriteLine(line);


            //3 Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
            foreach (var sentence in text.GetSentencesWithoutConsonants(3))
            {
                Console.WriteLine(sentence.SentenceToString());
            }
            Console.WriteLine(line);

            //4 В некотором предложении текста слова заданной длины заменить указанной подстрокой, 
            //длина которой может не совпадать с длиной слова.

            //Есть два варианта

            //1 Передается строка и метод по которому ее нужно распарсить.
            var variant1 = text.ReplaceWordInSentence(0, 3, "строка, с различными элементами", parser.ParseSentence);

            Console.WriteLine(variant1.SentenceToString());

            Console.WriteLine(line);

            //2 Передается коллекция объектов типа ISentenceItem.
            var variant2 = text.ReplaceWordInSentence(0, 6,
                parser.ParseSentence("строка, с различными элементами").Items.ToList());

            Console.WriteLine(variant2.SentenceToString());

            Console.WriteLine(line);

            Console.ReadKey();
        }
    }
}