using System.ComponentModel.DataAnnotations;

namespace AksaraBackendApi.Features.AuthManagement
{
    public class RegisterDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string PasswordConfirmation { get; set; } = string.Empty;
    }
}
