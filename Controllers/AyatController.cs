using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuranApi.Interfaces;
using QuranApi.Models;
using QuranApi.Services;

namespace QuranApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AyatController : ControllerBase
    {
        private readonly ISurahAyatService _service;

        public AyatController(ISurahAyatService service)
        {
            _service = service;
        }

        // GET: api/ayah
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ayah>>> GetAllAyahs()
        {
            return Ok(await _service.GetAllAyatsAsync());
        }

        // GET: api/ayah/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Ayah>> GetAyahById(int id)
        {
            var ayah = await _service.GetAyatByIdAsync(id);

            if (ayah == null)
            {
                return NotFound();
            }

            return Ok(ayah);
        }
    }
}
