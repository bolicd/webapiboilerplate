using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using WebApi2OwinBoilerplate.Models;

namespace WebApi2OwinBoilerplate.Database
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }

        public DbSet<Tweet> Tweet { get; set; }
        public DbSet<Follower> Follower { get; set; }
    }
}