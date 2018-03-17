using System.Web.Http;

namespace WebApi2OwinBoilerplate.Controllers
{
    [RoutePrefix("api")]
    public class TestController : ApiController
    {
        [Route("v1/test")]
        public IHttpActionResult GetV1()
        {
            return Ok(new { value = "Hello" });
        }

        [Route("v2/test")]
        public IHttpActionResult GetV2()
        {
            return Ok(new { value = "Hello V2" });
        }
    }
}
