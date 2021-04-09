using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Exercises.Section11_Flyweight
{
    public class Sentence
    {
        private readonly string[] words;
        private readonly Dictionary<int, WordToken> wordTokens = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            words = plainText.Split(' ');
        }

        public WordToken this[int index]
        {
            get
            {
                if (!wordTokens.ContainsKey(index))
                {
                    wordTokens[index] = new WordToken();
                }
                return wordTokens[index];
            }
        }

        public override string ToString()
        {
            int i = -1;
            return string.Join(" ", words.Select(word =>
            {
                i++;
                if (wordTokens.ContainsKey(i) && wordTokens[i].Capitalize)
                {
                    return word.ToUpperInvariant();
                }
                return word;
            }));
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
}
