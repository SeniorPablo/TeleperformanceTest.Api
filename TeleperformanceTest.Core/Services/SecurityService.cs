using TeleperformanceTest.Core.Entities;
using TeleperformanceTest.Core.Interfaces;
using TeleperformanceTest.Core.Interfaces.Services;
using System.Threading.Tasks;
using TeleperformanceTest.Core.Exceptions;

namespace TeleperformanceTest.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            var user = await _unitOfWork.SecurityRepository.GetLoginByCredentials(userLogin);
            if (user == null)
            {
                throw new BussinesException("El usuario no existe");
            }
            return user;
        }

        public async Task RegisterUser(Security security)
        {
            await _unitOfWork.SecurityRepository.Add(security);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
