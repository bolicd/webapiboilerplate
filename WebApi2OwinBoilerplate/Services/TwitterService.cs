using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi2OwinBoilerplate.DTO;
using WebApi2OwinBoilerplate.Models;
using WebApi2OwinBoilerplate.Repository;

namespace WebApi2OwinBoilerplate.Services
{
    public class TwitterService : ITwitterService
    {
        private GenericRepository<Tweet> _tweetRepo;
        private Uow _uow;

        public TwitterService(GenericRepository<Tweet> tweetRepo, Uow uow)
        {
            _tweetRepo = tweetRepo;
            _uow = uow;
        }

        public async Task<bool> AddNewTweet(string tweet, string userId)
        {
            if (!string.IsNullOrEmpty(tweet))
            {
                _tweetRepo.Add(new Tweet()
                {
                    TweetText = tweet,
                    UserId = Guid.Parse(userId),
                    TweetAdded = DateTime.Now
                });
                var result = await _uow.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TweetResultDto>> GetTweets()
        {
            var userId = ClaimsPrincipal.Current.FindFirst("uid")?.Value;
            var result = await _tweetRepo.FindAsync(x => x.UserId.ToString().Equals(userId));
            return result.Select(x => new TweetResultDto()
            {
                DateAdded = x.TweetAdded,
                Tweet = x.TweetText
            });
        }
    }
}