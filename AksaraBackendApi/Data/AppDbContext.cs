using AksaraBackendApi.Features.AuthManagement;
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
    }
}
