using AksaraBackendApi.Features.EmployeeManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;

namespace AksaraBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = await _employeeService.GetAllEmployeesAsync();
            return Ok(request);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(request);

        }
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeAddDto dto)
        {
            var request = await _employeeService.AddEmployeeAsync(dto);
            return Ok(request);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, EmployeeAddDto dto)
        {
            var req = await _employeeService.UpdateEmployeeAsync(id, dto);
            return Ok(req);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var req = await _employeeService.DeleteEmployeeAsync(id);
            return Ok(req);
        }
    }
}
