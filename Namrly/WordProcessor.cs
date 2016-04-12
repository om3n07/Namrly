using System;
using System.Threading.Tasks;

namespace Namrly
{
    public class WordProcessor
    {
        public static async Task<string> GetRandomProductName(bool includeImmatureSuffixes)
        {
            var r = new Random();
            var result = await RandomWordProxy.GetRandomWord(r.Next(0, 15));

            if (includeImmatureSuffixes && r.Next(2) == 0)
            {
                // Be Immature
                result += (ImmatureSuffixes)r.Next(0, Enum.GetNames(typeof(ImmatureSuffixes)).Length);
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

    enum ImmatureSuffixes
    {
        poop
    }
}
