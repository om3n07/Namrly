using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Namrly.WordnikApi;

using Newtonsoft.Json;

namespace Namrly
{
    public class RandomWordProxy
    {
        private readonly string _wordnikApiKey;

        public RandomWordProxy()
        {
            this._wordnikApiKey = GetApiKey();
        }

        public async Task<string> GetRandomWord(int len = 0)
        {
            using (var client = new HttpClient())
            {
                var request = "http://randomword.setgetgo.com/get.php";
                if (len < 2 || len > 5) len = 3;
                request += "?len=" + len;

                var response = await client.GetAsync(request);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<WordnikResponse> GetSynonyms(string word)
        {
            using (var client = new HttpClient())
            {
                var request =
                    "http://api.wordnik.com:80/v4/word.json/"+word+ "/relatedWords?useCanonical=false&relationshipTypes=synonym&limitPerRelationshipType=99&api_key="+ this._wordnikApiKey;
                var response = await client.GetAsync(request);
                var jsonString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<WordnikResponse>>(jsonString).FirstOrDefault();
            }
        }

        private string GetApiKey()
        {
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "wordNikCred.txt");
            
            return System.IO.File.ReadAllText(path);
        }
    }
}