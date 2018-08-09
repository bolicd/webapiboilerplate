using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi2OwinBoilerplate.Models;

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

        [Authorize]
        [Route("v2/test")]
        public IHttpActionResult GetV2()
        {
            return Ok("OK");
        }

        [Route("v1/users")]
        public List<string> GetUsers()
        {
            return new List<string>() { "1", "2" };
        }
    }
}
