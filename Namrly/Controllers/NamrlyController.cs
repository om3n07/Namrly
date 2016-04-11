using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Namrly.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/")]
    public class NamrlyController : ApiController
    {
        [HttpGet]
        [Route("namrly")]
        public async System.Threading.Tasks.Task<HttpResponseMessage> GetProductName()
        {
            var envData = await WordProcessor.GetRandomProductName();
            return Request.CreateResponse(HttpStatusCode.OK, envData);
        }
    }
}