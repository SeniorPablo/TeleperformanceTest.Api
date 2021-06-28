using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TeleperformanceTest.Infrastructure.Data;
using TeleperformanceTest.Infrastructure.Repositories;
using TeleperformanceTest.Core.Entities;
using TeleperformanceTest.Core.Interfaces.Repository;

namespace TeleperformanceTest.Infraestructure.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(TeleperformanceTestContext context) : base(context) { }
        public async Task<Company> GetCompanyByIdentification(int id)
        {
            return await _entities.Where(c => c.IdentificationNumber == id.ToString()).FirstOrDefaultAsync();
        }
    }
}
