
using Microsoft.EntityFrameworkCore;
using AksaraBackendApi.Data;

namespace AksaraBackendApi.Features.ReaportManagement
{
    public class ReportService : IReaportService
    {
        private readonly AppDbContext _appDbContext;
        public ReportService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<LaporanModel> CreateLaporanAsync(LaporanAddDto laporanAddDto)
        {
            var laporan = new LaporanModel
            {
                KategoriMasalah = laporanAddDto.KategoriMasalah,
                DeskripsiMasalah = laporanAddDto.DeskripsiMasalah,
                LokasiMasalah = laporanAddDto.LokasiMasalah,
                TanggalLaporan = laporanAddDto.TanggalLaporan,
                FotoLaporan = laporanAddDto.FotoLaporan,
                IdWargaId = laporanAddDto.IdWargaId
            };

            await _appDbContext.Laporans.AddAsync(laporan);
            await _appDbContext.SaveChangesAsync();

            return new LaporanModel
            { 
                Id = laporan.Id,
                KategoriMasalah = laporan.KategoriMasalah,
                DeskripsiMasalah = laporan.DeskripsiMasalah,
                LokasiMasalah = laporan.LokasiMasalah,
                TanggalLaporan = laporan.TanggalLaporan,
                FotoLaporan = laporan.FotoLaporan,
                IdWargaId = laporan.IdWargaId
            };
        }

        public async Task<List<LaporanModel>> GetAllLaporanAsync()
        {
            var laporans = await _appDbContext.Laporans.ToListAsync();
            if (laporans.Count == 0)
            {
                return new List<LaporanModel>();
            }
            return laporans;
        }

        public async Task<LaporanModel> GetLaporanByIdAsync(int id)
        {
            var laporan = await _appDbContext.Laporans.FirstOrDefaultAsync(l => l.Id == id);
            if (laporan == null)
            {
                throw new Exception("Laporan tidak ditemukan.");
            }
            return laporan;
        }


        public async Task<bool> DeleteLaporanAsync(int id)
        {
            var laporan = await _appDbContext.Laporans.FirstOrDefaultAsync(l => l.Id == id);
            if (laporan == null)
            {
                throw new Exception("Laporan tidak ditemukan.");
            }
            _appDbContext.Laporans.Remove(laporan);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
