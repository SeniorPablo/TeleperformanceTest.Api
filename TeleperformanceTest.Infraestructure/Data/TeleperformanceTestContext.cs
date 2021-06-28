using Microsoft.EntityFrameworkCore;
using TeleperformanceTest.Core.Entities;
using System.Reflection;

namespace TeleperformanceTest.Infrastructure.Data
{
    public partial class TeleperformanceTestContext : DbContext
    {
        public TeleperformanceTestContext(){ }

        public TeleperformanceTestContext(DbContextOptions<TeleperformanceTestContext> options)
        : base(options){ }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<IdentificationType> IdentificationTypes { get; set; }
        public virtual DbSet<Security> Securities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
