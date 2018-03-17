using System.Web.Http;

namespace WebApi2OwinBoilerplate.Controllers
{
    [RoutePrefix("api")]
    public class TestController : ApiController
    {
        //structure map test
        private MockRepo _repo;

        public TestController(MockRepo repo)
        {
            _repo = repo;
        }
        [Route("v1/test")]
        public IHttpActionResult GetV1()
        {
            return Ok(new { value = "Hello" });
        }

        [Route("v2/test")]
        public IHttpActionResult GetV2()
        {
            return Ok(_repo.GetElements());
        }
    }
}
