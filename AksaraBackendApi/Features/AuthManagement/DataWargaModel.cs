using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using System.ComponentModel.DataAnnotations;

namespace AksaraBackendApi.Features.AuthManagement
{
    public class DataWargaModel
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string NamaLengkap { get; set; } = string.Empty;
        public string Nik { get; set; } = string.Empty;
        [Phone]
        public string NoTelepon { get; set; } = string.Empty;
        public string Wilayah { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime TanggalLahir { get; set; }
    }
}
