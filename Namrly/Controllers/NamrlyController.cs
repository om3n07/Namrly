using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Namrly.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/namrly")]
    public class NamrlyController : ApiController
    {
        private WordProcessor _wp;
        public WordProcessor WordProcessor => this._wp ?? (this._wp = new WordProcessor());

        /// <summary>
        /// Gets a randomly generated start-up name
        /// </summary>
        /// <param name="baseWord"></param>
        /// <param name="includeAdditionalSuffixes"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetProductName(string baseWord = null, bool includeAdditionalSuffixes = false)
        {
            string randomProductName;
            if (baseWord == null) randomProductName = await this.WordProcessor.GetRandomProductName(includeAdditionalSuffixes);
            else randomProductName = await this.WordProcessor.GetRandomRelatedProductName(baseWord, includeAdditionalSuffixes);

            return this.Request.CreateResponse(HttpStatusCode.OK, randomProductName);
        }
    }
}