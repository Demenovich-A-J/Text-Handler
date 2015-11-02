using System;
using System.IO;
using System.Linq;
using System.Text;
using Text_Handler.Parser;

namespace Text_Handler
{
    public class Program
    {
        private static void Main(string[] args)
        {
            const string line = "||============================================================||";
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
            text.SentencesWithoutConsonants(3);
            Console.WriteLine(text.TextToString());
            Console.WriteLine(line);

            //4 В некотором предложении текста слова заданной длины заменить указанной подстрокой, 
            //длина которой может не совпадать с длиной слова.

            //Есть два варианта

            //1 Передается строка и метод по которому ее нужно распарсить.
            text.ReplaceWordInSentence(0, 4, "строка, с различными элементами", parser.ParseSentence);

            Console.WriteLine(text.TextToString());

            Console.WriteLine(line);

            //2 Передается коллекция объектов типа ISentenceItem.
            text.ReplaceWordInSentence(0, 6, parser.ParseSentence("строка, с различными элементами").Items.ToList());

            Console.WriteLine(text.TextToString());

            Console.WriteLine(line);

            Console.ReadKey();
        }
    }
}