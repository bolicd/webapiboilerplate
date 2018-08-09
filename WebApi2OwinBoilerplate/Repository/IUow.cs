using System.Threading.Tasks;

namespace WebApi2OwinBoilerplate.Repository
{
    interface IUow
    {
        int Complete();
        Task<int> CompleteAsync();
    }
}
