using System.ComponentModel.DataAnnotations;

namespace AksaraBackendApi.Features.AuthManagement
{
    public class DataDto
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string NamaLengkap { get; set; } = string.Empty;
        [Required]
        public string Nik { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string NoTelepon { get; set; } = string.Empty;
        [Required]
        public string Wilayah { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [Required]
        public DateTime TanggalLahir { get; set; }
    }
}
