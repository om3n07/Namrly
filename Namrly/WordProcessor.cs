using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Namrly
{
    public class WordProcessor
    {
        public static async Task<string> GetRandomProductName()
        {
            var r = new Random();
            var result = await RandomWordProxy.GetRandomWord(r.Next(0, 15));
            var suffix = (Suffixes)r.Next(1, 3);

            return result + suffix;
        }
    }

    enum Suffixes
    {
        ly,
        r,
        bits
    }
}