using System.Collections.Generic;
using System.Threading.Tasks;
using TeleperformanceTest.Core.Entities;

namespace TeleperformanceTest.Core.Interfaces.Services
{
    public interface ITypeIdentificationService
    {
        Task<List<IdentificationType>> GetIdentificationTypes();
    }
}
