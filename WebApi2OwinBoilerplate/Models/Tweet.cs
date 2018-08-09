using System;

namespace WebApi2OwinBoilerplate.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        public string TweetText { get; set; }
        public DateTime TweetAdded { get; set; }
        public string TweetDescription { get; set; }
        public Guid UserId { get; set; }
    }
}