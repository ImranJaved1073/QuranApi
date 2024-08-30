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

            return ayah;
        }


        // POST: api/ayah
        [HttpPost]
        public async Task<ActionResult<Ayah>> PostAyah(Ayah ayah)
        {
            await _service.CreateAyatAsync(ayah);

            return CreatedAtAction(nameof(GetAyahById), new { id = ayah.AyaID }, ayah);
        }

        [HttpPost("bulk")]
        public async Task<ActionResult<IEnumerable<Ayah>>> PostAyahs(List<Ayah> ayahs)
        {
            if (ayahs == null || !ayahs.Any())
            {
                return BadRequest("The list of Ayahs is null or empty.");
            }

            foreach (var ayah in ayahs)
            {
                await _service.CreateAyatAsync(ayah);
            }

            return Ok();
        }


        // PUT: api/ayah/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAyah(int id, Ayah ayah)
        {
            if (id != ayah.AyaID)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAyatAsync(ayah);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _service.AyatExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ayah/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAyah(int id)
        {
            var ayah = await _service.GetAyatByIdAsync(id);
            if (ayah == null)
            {
                return NotFound();
            }

            await _service.DeleteAyatAsync(id);

            return NoContent();
        }

    }
}
