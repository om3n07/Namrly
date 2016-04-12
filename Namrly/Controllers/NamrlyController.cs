using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Namrly.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/")]
    public class NamrlyController : ApiController
    {
        /// <summary>
        /// Gets a randomly generated start-up name
        /// </summary>
        /// <param name="includeImmatureSuffixes"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("namrly")]
        public async Task<HttpResponseMessage> GetProductName(bool includeImmatureSuffixes = false)
        {
            var randomProductName = await WordProcessor.GetRandomProductName(includeImmatureSuffixes);
            return Request.CreateResponse(HttpStatusCode.OK, randomProductName);
        }
    }
}