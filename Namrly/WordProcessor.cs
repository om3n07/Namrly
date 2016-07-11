using System;
using System.Threading.Tasks;

namespace Namrly
{
    public class WordProcessor
    {
        private static readonly Random R = new Random();

        private RandomWordProxy _randomWordProxy;

        public RandomWordProxy RandomWordProxy => this._randomWordProxy ?? (this._randomWordProxy = new RandomWordProxy());

        public async Task<string> GetRandomProductName(bool includeAdditionalSuffixes = false)
        {
            var result = await this.RandomWordProxy.GetRandomWord(R.Next(0, 5));
            result += GetSuffix(includeAdditionalSuffixes);
            return (result);
        }

        public async Task<string> GetRandomRelatedProductName(string baseWord, bool includeAdditionalSuffixes = false)
        {
            var response = await this.RandomWordProxy.GetRandomSynonym(baseWord);
            var result = response.Words[R.Next(0, response.Words.Count)];
            result += GetSuffix(includeAdditionalSuffixes);

            return (result);
        }

        private static string GetSuffix(bool includeAdditionalSuffixes)
        {
            if (includeAdditionalSuffixes && R.Next(2) == 0) return ((AdditionalSuffixes)R.Next(0, Enum.GetNames(typeof(AdditionalSuffixes)).Length)).ToString();
            return ((Suffixes)R.Next(0, Enum.GetNames(typeof(Suffixes)).Length)).ToString();
        }
    }

    enum Suffixes
    {
        ly,
        r,
        bits,
    }

    enum AdditionalSuffixes
    {
        poop
    }
}
