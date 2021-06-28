using TeleperformanceTest.Core.Entities;
using System.Threading.Tasks;

namespace TeleperformanceTest.Core.Interfaces.Repository
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}
