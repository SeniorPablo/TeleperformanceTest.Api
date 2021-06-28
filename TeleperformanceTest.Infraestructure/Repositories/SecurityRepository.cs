using Microsoft.EntityFrameworkCore;
using TeleperformanceTest.Core.Entities;
using TeleperformanceTest.Core.Interfaces.Repository;
using TeleperformanceTest.Infrastructure.Data;
using System.Threading.Tasks;

namespace TeleperformanceTest.Infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(TeleperformanceTestContext context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(s => s.User == login.User);
        }
    }
}
