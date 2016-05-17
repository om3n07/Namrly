using System;
using System.Threading.Tasks;

namespace Namrly
{
    public class WordProcessor
    {
        public static async Task<string> GetRandomProductName(bool includeAdditionalSuffixes)
        {
            var r = new Random();
            var result = await RandomWordProxy.GetRandomWord(r.Next(0, 15));

            if (includeAdditionalSuffixes && r.Next(2) == 0)
            {
                // For Jon
                result += (AdditionalSuffixes)r.Next(0, Enum.GetNames(typeof(AdditionalSuffixes)).Length);
            }
            else
            {
                result += (Suffixes)r.Next(0, Enum.GetNames(typeof(Suffixes)).Length);
            }

            return (result);
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
