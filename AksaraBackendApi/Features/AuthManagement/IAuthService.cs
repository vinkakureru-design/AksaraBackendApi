namespace AksaraBackendApi.Features.AuthManagement
{
    public interface IAuthService
    {
        Task<DataWargaModel> RegisterAsync(RegisterDto registerDto);
        Task<DataWargaModel> LoginAsync(LoginDto loginDto);
        Task<DataWargaModel> DataWargaAsync(DataDto dataDto);
    }
}
