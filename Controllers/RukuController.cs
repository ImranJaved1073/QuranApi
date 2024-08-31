using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuranApi.Interfaces;
using QuranApi.Models;

namespace QuranApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RukuController : ControllerBase
    {
        private readonly ISurahAyatService _service;

        public RukuController(ISurahAyatService service)
        {
            _service = service;
        }

        [HttpGet("{suraId}/{rukuId}")]
        public async Task<IActionResult> Get(int suraId,int rukuId)
        {
            var rukuAyats = await _service.GetAyatsInSurahByRukuIdAsync(suraId,rukuId);

            if (rukuAyats == null)
            {
                return NotFound();
            }

            return Ok(rukuAyats);
        }

        [HttpGet("{rukuId}")]
        public async Task<IActionResult> GetRuku(int rukuId)
        {
            var rukuAyats = await _service.GetAyatsByRukuIdAsync(rukuId);

            if (rukuAyats == null)
            {
                return NotFound("Not Found");
            }

            return Ok(rukuAyats);
        }
    }
}
