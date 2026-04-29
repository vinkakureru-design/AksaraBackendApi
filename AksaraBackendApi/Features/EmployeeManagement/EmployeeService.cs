using AksaraBackendApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel.Design;

namespace AksaraBackendApi.Features.EmployeeManagement
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeModel>> GetAllEmployeesAsync()
        {
            var employees = await _context.EmployeeModels.ToListAsync();
            if (employees == null) throw new Exception("tidak ada employee");
            return employees;
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.EmployeeModels.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null) throw new Exception("employee tidak ditemukan");
            return employee;
        }
        public async Task<EmployeeModel> AddEmployeeAsync(EmployeeAddDto request)
        {
            var newEmployee = new EmployeeModel
            {
                Username = request.Username,
                Password = request.Password,
                Role = request.Role,
                NIP = request.NIP,
                Email = request.Email,
                Phone = request.Phone
            };

            await _context.EmployeeModels.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee;
        }

        public async Task<EmployeeModel> UpdateEmployeeAsync(int id, EmployeeAddDto request)
        {
            var findEmployee = await _context.EmployeeModels.FirstOrDefaultAsync(i => i.Id == id);
            if (findEmployee == null) throw new Exception("Employee tidak ditemukan");

            findEmployee.Username = request.Username;
            findEmployee.Password = request.Password;
            findEmployee.Role = request.Role;
            findEmployee.NIP = request.NIP;
            findEmployee.Email = request.Email;
            findEmployee.Phone = request.Phone;

            _context.EmployeeModels.Update(findEmployee);
            await _context.SaveChangesAsync();
            return findEmployee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var findEmployee = await _context.EmployeeModels.FirstOrDefaultAsync(j => j.Id == id);
            if (findEmployee == null) throw new Exception("Employee tidak ditemukan");

            _context.EmployeeModels.Remove(findEmployee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
