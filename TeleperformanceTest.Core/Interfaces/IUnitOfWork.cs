using System;
using System.Threading.Tasks;
using TeleperformanceTest.Core.Interfaces.Repository;

namespace TeleperformanceTest.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        ITypeIdentificationRepository IdentificationTypeRepository { get; }
        ISecurityRepository SecurityRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
