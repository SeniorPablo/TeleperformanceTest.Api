using System.Threading.Tasks;
using TeleperformanceTest.Core.Entities;

namespace TeleperformanceTest.Core.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyByIdentification(int id);
        Task<bool> UpdateCompany(Company entity);
    }
}
