using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Text_Handler.Interfaces;
using Text_Handler.Parser;
using Text_Handler.TextObjects;

namespace Text_Handler
{
    public class Text
    {
        public IList<ISentence> Sentences { get; set; }

        public ISentence this[int index]
        {
            get { return this.Sentences[index]; }
        }

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
        public IEnumerable<ISentence> SentencesInAscendingOrder()
        {
            return Sentences.OrderBy(x => x.Items.Count);
        }

        public IEnumerable<ISentence> GetInterrogativeSentences()
        {
            return Sentences.Where(x => x.IsInterrogative());
        }

        public IEnumerable<IEnumerable<ISentenceItem>> GetSentencesWithoutConsonants(int length)
        {
            return Sentences.Select( x => x.RemoveConsonantsWords(length));
        }

        /// <summary>
        /// Replaces the word in the selected sentence on list of items type ISentenceItem.
        /// </summary>
        /// <param name="index">Index of sentence.</param>
        /// <param name="length">Length of word to replace.</param>
        /// <param name="elements">ISentenceItem elements that will be insert instead word into the sentence.</param>
        public ISentence ReplaceWordInSentence(int index, int length, IList<ISentenceItem> elements)
        {
            return new Sentence(Sentences[index].ReplaceWordByElements(length, elements));
        }

        //TODO remove ovrride and add method TextToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var sentence in Sentences)
            {
                sb.Append(sentence + "\n");
            }

            return sb.ToString();
        }
    }
}