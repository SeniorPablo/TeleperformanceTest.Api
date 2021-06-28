using TeleperformanceTest.Core.Entities;
using System.Threading.Tasks;

namespace TeleperformanceTest.Core.Interfaces.Services
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}
