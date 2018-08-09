using System.Threading.Tasks;
using WebApi2OwinBoilerplate.Database;

namespace WebApi2OwinBoilerplate.Repository
{
    public class Uow : IUow
    {
        private AuthContext dbContext;

        public Uow(AuthContext context)
        {
            dbContext = context;
        }
        public int Complete()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}