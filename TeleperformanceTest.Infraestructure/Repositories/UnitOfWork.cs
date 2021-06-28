using System.Threading.Tasks;
using TeleperformanceTest.Core.Interfaces;
using TeleperformanceTest.Core.Interfaces.Repository;
using TeleperformanceTest.Infraestructure.Repositories;
using TeleperformanceTest.Infrastructure.Data;

namespace TeleperformanceTest.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TeleperformanceTestContext _context;
        private readonly ICompanyRepository _companyRepository;
        private readonly ITypeIdentificationRepository _typeIdentificationRepository;
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(TeleperformanceTestContext context)
        {
            _context = context;
        }
        public ICompanyRepository CompanyRepository => _companyRepository ?? new CompanyRepository(_context);
        public ITypeIdentificationRepository IdentificationTypeRepository => _typeIdentificationRepository ?? new IdentificationTypeRepository(_context);
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
