using System.Threading.Tasks;
using TeleperformanceTest.Core.Entities;

namespace TeleperformanceTest.Core.Interfaces.Repository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> GetCompanyByIdentification(int id);
    }
}
