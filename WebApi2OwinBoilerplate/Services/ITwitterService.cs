using System;
using System.Threading.Tasks;

namespace WebApi2OwinBoilerplate.Services
{
    interface ITwitterService
    {
        Task<bool> AddNewTweet(string tweet,Guid userId);
    }
}
