using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using AksaraBackendApi.Features.ReaportManagement;

namespace AksaraBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaporanController : ControllerBase
    {
        private readonly IReaportService _reaportService;
        public LaporanController(IReaportService reaportService)
        {
            _reaportService = reaportService;
        }

        [HttpPost("laporanAdd")]
        public async Task<IActionResult> GenerateLaporan([FromBody] LaporanAddDto laporanDto)
        {
            try
            {
                var result = await _reaportService.CreateLaporanAsync(laporanDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLaporan()
        {
            try
            {
                var result = await _reaportService.GetAllLaporanAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLaporanById(int id)
        {
            try
            {
                var result = await _reaportService.GetLaporanByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaporan(int id)
        {
            try
            {
                var result = await _reaportService.DeleteLaporanAsync(id);
                if (result)
                {
                    return Ok("Laporan berhasil dihapus.");
                }
                else
                {
                    return NotFound("Laporan tidak ditemukan.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
