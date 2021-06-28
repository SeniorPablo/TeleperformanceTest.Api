using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleperformanceTest.Core.Entities;
using TeleperformanceTest.Core.Interfaces.Repository;
using TeleperformanceTest.Infrastructure.Data;
using TeleperformanceTest.Infrastructure.Repositories;

namespace TeleperformanceTest.Infraestructure.Repositories
{
    public class IdentificationTypeRepository : BaseRepository<IdentificationType>, ITypeIdentificationRepository
    {
        public IdentificationTypeRepository(TeleperformanceTestContext context) : base(context) { }

        public async Task<List<IdentificationType>> GetIdentificationTypes()
        {
            return await _entities.ToListAsync();
        }
    }
}
