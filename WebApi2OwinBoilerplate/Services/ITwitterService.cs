using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi2OwinBoilerplate.DTO;

namespace WebApi2OwinBoilerplate.Services
{
    interface ITwitterService
    {
        Task<bool> AddNewTweet(string tweet,string userId);
        Task<IEnumerable<TweetResultDto>> GetTweets();
    }
}
