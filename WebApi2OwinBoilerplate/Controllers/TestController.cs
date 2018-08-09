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

        [Authorize]
        [Route("v2/test")]
        public IHttpActionResult GetV2()
        {
            return Ok(_repo.GetElements());
        }

        [Route("v1/users")]
        public List<UserDto> GetUsers()
        {   
            //automapper testing
            var list = _repo.GetUsers().Select(x => Mapper.Map<UserDto>(x));
            return list.ToList();
        }
    }
}
