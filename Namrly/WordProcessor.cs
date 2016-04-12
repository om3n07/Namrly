using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Namrly
{
    public class WordProcessor
    {
        public static string GetRandomProductName(bool includeImmatureSuffixes)
        {
            var r = new Random();
            var result = RandomWordProxy.GetRandomWord(r.Next(0, 15));
            Suffixes suffix;
            
            if (includeImmatureSuffixes && r.Next(0, 1) == 1)
            {
                // Be Immature
                suffix = (Suffixes)r.Next(0, Enum.GetNames(typeof(ImmatureSuffixes)).Length);
            }
            else
            {
                suffix = (Suffixes)r.Next(0, Enum.GetNames(typeof(Suffixes)).Length);
            }

            return result + suffix;
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
