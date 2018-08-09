using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi2OwinBoilerplate.DTO;
using WebApi2OwinBoilerplate.Services;

namespace WebApi2OwinBoilerplate.Controllers
{
    [RoutePrefix("api/twitter")]
    public class TweetController : ApiController
    {
        private TwitterService _twitterService;

        public TweetController(TwitterService twitterService)
        {
            _twitterService = twitterService;
        }

        [Authorize]
        [HttpPost]
        public async  Task<IHttpActionResult> PostTwitter(TweetDto data)
        {
            var userId = ClaimsPrincipal.Current.FindFirst("uid")?.Value;
            var result = await _twitterService.AddNewTweet(data.Tweet, userId);
            return Ok();
        }


        [Authorize]
        [HttpGet]
        public async Task<IHttpActionResult> GetTweets()
        {
            var userId = ClaimsPrincipal.Current.FindFirst("uid")?.Value;
            var result = await _twitterService.GetTweets();
            return Ok(result);
        }
    }
}