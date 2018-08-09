using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
    }
}