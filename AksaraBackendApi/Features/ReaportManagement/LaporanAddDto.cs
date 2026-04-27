using AksaraBackendApi.Features.AuthManagement;
using System.ComponentModel.DataAnnotations;

namespace AksaraBackendApi.Features.ReaportManagement
{
    public class LaporanAddDto
    {
        [Key]
        [Required]
        public string KategoriMasalah { get; set; } = string.Empty;
        [Required]
        public string DeskripsiMasalah { get; set; } = string.Empty;
        [Required]
        public string LokasiMasalah { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime TanggalLaporan { get; set; }
        public string FotoLaporan { get; set; } = string.Empty;


        public int IdWargaId { get; set; }
        public DataWargaModel? IdWarga { get; set; }
    }
}
