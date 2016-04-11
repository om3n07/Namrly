using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace Namrly
{
    public static class RandomWordProxy
    {
        public static async Task<string> GetRandomWord(int len = 0)
        {
            using (var client = new HttpClient())
            {
                var request = "http://randomword.setgetgo.com/get.php";

                if (len >= 3 && len <= 20) request += "?len=" + len;

                var response = await client.GetAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}