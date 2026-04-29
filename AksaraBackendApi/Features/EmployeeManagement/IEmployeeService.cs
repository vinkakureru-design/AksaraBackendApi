namespace AksaraBackendApi.Features.EmployeeManagement
{
    public interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetAllEmployeesAsync();
        Task<EmployeeModel?> GetEmployeeByIdAsync(int id);
        Task<EmployeeModel> AddEmployeeAsync(EmployeeAddDto employeeAddDto);
        Task<EmployeeModel?> UpdateEmployeeAsync(int id, EmployeeAddDto employeeAddDto);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
