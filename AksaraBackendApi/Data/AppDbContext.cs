using AksaraBackendApi.Features.AuthManagement;
using AksaraBackendApi.Features.EmployeeManagement;
using AksaraBackendApi.Features.ReaportManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace AksaraBackendApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<DataWargaModel> DataWargaModels { get; set; }
        public DbSet<LaporanModel> Laporans { get; set; }
        public DbSet<EmployeeModel> EmployeeModels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string adminPasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123");
            modelBuilder.Entity<EmployeeModel>(
                entity =>
                {
                    entity.HasData(
                        new EmployeeModel
                        {
                            Id = 1,
                            Username = "admin",
                            Password = adminPasswordHash,
                            Role = "Admin",
                            NIP = "123456789",
                            Email = "admin@myvin.cafe",
                            Phone = "081234567890"
                        }
                        );
                });
        }
    }
}
