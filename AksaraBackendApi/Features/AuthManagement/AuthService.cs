using AksaraBackendApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AksaraBackendApi.Features.AuthManagement
{
    public class AuthService :  IAuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<DataWargaModel> RegisterAsync(RegisterDto registerDto)
        {
            var existingUser = await _context.DataWargaModels
                .FirstOrDefaultAsync(u => u.Email == registerDto.Email);
            if (existingUser != null)
            {
                throw new Exception("Email sudah terdaftar.");
            }
            var confirmPassword = registerDto.PasswordConfirmation;
            if (registerDto.Password != confirmPassword)
            {
                throw new Exception("Password dan konfirmasi password tidak cocok.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            var newUser = new DataWargaModel
            {
                Email = registerDto.Email,
                PasswordHash = passwordHash
            };
            _context.DataWargaModels.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<DataWargaModel> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.DataWargaModels
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null)
            {
                throw new Exception("Email tidak ditemukan!");
            }
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                throw new Exception("Password salah!");
            }
            return user;
        }

        public async Task<DataWargaModel> DataWargaAsync(DataDto dataDto)
        {
            var user = await _context.DataWargaModels.FirstOrDefaultAsync(u => u.Email == dataDto.Email);
            if (user == null) throw new Exception("Data warga tidak ditemukan.");

            // Update propertinya
            user.NamaLengkap = dataDto.NamaLengkap;
            user.Nik = dataDto.Nik;
            user.NoTelepon = dataDto.NoTelepon;
            user.Wilayah = dataDto.Wilayah;
            user.TanggalLahir = dataDto.TanggalLahir;

            _context.DataWargaModels.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
