namespace AksaraBackendApi.Features.ReaportManagement
{
    public interface IReaportService
    {
         Task<LaporanModel> CreateLaporanAsync(LaporanAddDto laporanAddDto);
         Task<List<LaporanModel>> GetAllLaporanAsync();
         Task<LaporanModel> GetLaporanByIdAsync(int id);
         Task<bool> DeleteLaporanAsync(int id);
    }
}
