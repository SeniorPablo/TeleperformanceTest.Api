using System.Collections.Generic;
using System.Threading.Tasks;
using TeleperformanceTest.Core.Entities;
using TeleperformanceTest.Core.Interfaces;
using TeleperformanceTest.Core.Interfaces.Services;

namespace TeleperformanceTest.Core.Services
{
    public class IdentificationTypeService : ITypeIdentificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IdentificationTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<IdentificationType>> GetIdentificationTypes()
        {
           return await _unitOfWork.IdentificationTypeRepository.GetIdentificationTypes();
        }
    }
}
