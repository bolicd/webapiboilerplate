using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApi2OwinBoilerplate.Database
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}