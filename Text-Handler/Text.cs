using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Text_Handler.Interfaces;
using Text_Handler.Separators;
using Text_Handler.TextObjects;

namespace Text_Handler
{
    public class Text
    {
        public Text()
        {
            Sentences = new List<ISentence>();
        }

        public Text(IEnumerable<ISentence> sentences) : this()
        {
            foreach (var sentence in sentences)
            {
                Sentences.Add(sentence);
            }
        }

        public IList<ISentence> Sentences { get; set; }

        public ISentence this[int index] => Sentences[index];

        public IEnumerable<ISentence> GetSentencesInAscendingOrder()
        {
            return Sentences.OrderBy(x => x.Items.Count);
        }

        public IEnumerable<IWord> GetWordsFromInterrogativeSentences(int length)
        {
            var result = new List<IWord>();

            foreach (var sentence in Sentences.Where(sentence => sentence.IsInterrogative))
            {
                result.AddRange(sentence.GetWordsWithoutRepetition(length));
            }

            return result.GroupBy(x => x.Chars.ToLower()).Select(x => x.First()).ToList();
        }

        public void SentencesWithoutConsonants(int length)
        {
            Sentences = Sentences.Select(
                x =>
                    x.RemoveWordsBy(y => y.Length == length && y.IsСonsonant(VolwesSeparator.RussianVolwesSeparator)))
                .ToList();
        }

        /// <summary>
        ///     Replace word in selected sentence by list of items type ISentenceItem.
        /// </summary>
        /// <param name="index">Index of sentence.</param>
        /// <param name="length">Length of word to replace.</param>
        /// <param name="elements">ISentenceItem elements that will be insert instead word into the sentence.</param>
        public void ReplaceWordInSentence(int index, int length, IList<ISentenceItem> elements)
        {
            Sentences[index] = new Sentence(Sentences[index].ReplaceWordByElements((x => x.Length == length), elements));
        }

        /// <summary>
        ///     Replace word in selected sentence by line.
        /// </summary>
        /// <param name="index">Index of sentence.</param>
        /// <param name="length">Length of word to replace.</param>
        /// <param name="line">String with words and punctuation.</param>
        /// <param name="parseLine">Method to parse string and get new ISentence.</param>
        public void ReplaceWordInSentence(int index, int length, string line, Func<string, ISentence> parseLine)
        {
            Sentences[index] =
                new Sentence(Sentences[index].ReplaceWordByElements((x => x.Length == length), parseLine(line).Items));
        }

        public string TextToString()
        {
            var sb = new StringBuilder();

            foreach (var sentence in Sentences)
            {
                sb.Append(sentence.SentenceToString() + "\n");
            }

            return sb.ToString();
        }
    }
}