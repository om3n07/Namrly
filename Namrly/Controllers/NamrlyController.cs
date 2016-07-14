using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Namrly.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Namrly")]
    public class NamrlyController : ApiController
    {
        private WordProcessor _wp;
        public WordProcessor WordProcessor => this._wp ?? (this._wp = new WordProcessor());

        /// <summary>
        /// Gets a randomly generated start-up name
        /// </summary>
        /// <param name="includeAdditionalSuffixes"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("RandomStartupName")]
        public async Task<HttpResponseMessage> GetRandomStartupName(bool includeAdditionalSuffixes = false)
        {
            var randomProductName = await this.WordProcessor.GetRandomProductName(includeAdditionalSuffixes);

            return this.Request.CreateResponse(HttpStatusCode.OK, randomProductName);
        }

        /// <summary>
        /// Gets a startup name related to the base word
        /// </summary>
        /// <param name="baseWord"></param>
        /// <param name="includeAdditionalSuffixes"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("RelatedStartupName")]
        public async Task<HttpResponseMessage> GetRelatedStartupName(string baseWord, bool includeAdditionalSuffixes = false)
        {
            var randomProductName = await this.WordProcessor.GetRandomRelatedProductName(baseWord, includeAdditionalSuffixes);

            return this.Request.CreateResponse(HttpStatusCode.OK, randomProductName);
        }

        /// <summary>
        /// Gets all randomly generated start-up names from base word
        /// </summary>
        /// <param name="baseWord"></param>
        /// <param name="includeAdditionalSuffixes"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("AllRelatedStartupNames")]
        public async Task<HttpResponseMessage> GetAllRelatedStartupNames(string baseWord, bool includeAdditionalSuffixes = false)
        {
            var randomProductName = await this.WordProcessor.GetAllRelatedProductNames(baseWord, includeAdditionalSuffixes);

            return this.Request.CreateResponse(HttpStatusCode.OK, randomProductName);
        }
    }
}