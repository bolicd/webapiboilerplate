using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi2OwinBoilerplate.Models;

namespace WebApi2OwinBoilerplate
{
    public class MockRepo
    {
        public List<int> GetElements()
        {
            return new List<int>()
            {
                1,2,3
            };
        }

        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User(){ Id = 1, UserName="user1"},
                new User(){ Id = 2, UserName="user2"}
            };
        }
    }
}
