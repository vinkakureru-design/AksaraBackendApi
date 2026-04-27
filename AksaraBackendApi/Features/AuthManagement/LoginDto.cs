using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace AksaraBackendApi.Features.AuthManagement
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
