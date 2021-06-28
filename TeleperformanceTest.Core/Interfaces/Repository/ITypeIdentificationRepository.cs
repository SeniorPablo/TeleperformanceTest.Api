using System.Collections.Generic;
using System.Threading.Tasks;
using TeleperformanceTest.Core.Entities;

namespace TeleperformanceTest.Core.Interfaces.Repository
{
    public interface ITypeIdentificationRepository : IRepository<IdentificationType>
    {
        Task<List<IdentificationType>> GetIdentificationTypes();
    }
}
