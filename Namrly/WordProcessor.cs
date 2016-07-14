using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Namrly
{
    public class WordProcessor
    {
        private static readonly Random R = new Random();
        private readonly string[] _vowels = { "a", "e", "i", "o", "u" };

        private RandomWordProxy _randomWordProxy;

        public RandomWordProxy RandomWordProxy => this._randomWordProxy ?? (this._randomWordProxy = new RandomWordProxy());

        private bool ShouldDropVowel
        {
            get
            {
                // 25%
                var s = R.Next(0, 3);
                return s == 1;
            }
        }

        public async Task<string> GetRandomProductName(bool includeAdditionalSuffixes = false)
        {
            var result = await this.RandomWordProxy.GetRandomWord(R.Next(0, 5));
            if (this.ShouldDropVowel) this.DropVowel(ref result);
            result += GetRandomSuffix(includeAdditionalSuffixes);
            return (result);
        }

        public async Task<string> GetRandomRelatedProductName(string baseWord, bool includeAdditionalSuffixes = false)
        {
            string result;
            var response = await this.RandomWordProxy.GetSynonyms(baseWord);
            if (response?.Words != null)
            {
                result = response.Words[R.Next(0, response.Words.Count)];
                if (this.ShouldDropVowel) this.DropVowel(ref result);
                result += GetRandomSuffix(includeAdditionalSuffixes);
            }
            else  result = "no result found.";

            return (result);
        }

        public async Task<List<string>> GetAllRelatedProductNames(string baseword, bool includeAdditionalSuffixes = false)
        {
            if (baseword == null) throw new ArgumentNullException(nameof(baseword));

            var results = new List<string>();

            var response = await this.RandomWordProxy.GetSynonyms(baseword);
            if (response?.Words != null)
            {
                foreach (var word in response.Words)
                {
                    results.AddRange(AppendAllSuffixes(word));
                }
            }

            return results;
        }

        private static string GetRandomSuffix(bool includeAdditionalSuffixes)
        {
            if (includeAdditionalSuffixes && R.Next(2) == 0) return ((AdditionalSuffixes)R.Next(0, Enum.GetNames(typeof(AdditionalSuffixes)).Length)).ToString();
            return ((Suffixes)R.Next(0, Enum.GetNames(typeof(Suffixes)).Length)).ToString();
        }

        private static List<string> AppendAllSuffixes(string word)
        {
            if (word == null) throw new ArgumentNullException(nameof(word));
            var suffixes = Enum.GetValues(typeof(Suffixes)).Cast<Suffixes>();
            return suffixes.Select(suffix => word + suffix).ToList();
        }

        // Drops either the last letter or second to last letter if one of them is a vowel
        private bool DropVowel(ref string word)
        {
            if (word == null) throw new ArgumentNullException(nameof(word));
            var wasSuccessful = false;

            foreach (var v in this._vowels)
            {
                if (word.EndsWith(v))
                {
                    word = word.Substring(0, word.Length - 1);
                    break;
                }
                if (word[word.Length - 2].ToString() == v)
                {
                    var e = word[word.Length - 1];
                    word = word.Substring(0, word.Length - 2);
                    word += e;
                    break;
                }
            }

            return wasSuccessful;
        }
    }

    enum Suffixes
    {
        ly,
        r,
        rly,
        bits,
        ify,
    }

    enum AdditionalSuffixes
    {
        poop
    }
}
