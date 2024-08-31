using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuranApi.Interfaces;
using QuranApi.Models;

namespace QuranApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurahController : ControllerBase
    {
        private readonly ISurahService _surahService;
        private readonly ISurahAyatService _service;

        public SurahController(ISurahService surahService, ISurahAyatService service)
        {
            _surahService = surahService;
            _service = service;
        }

        // GET: api/Surah
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Surah>>> GetAllSurahs()
        {
            var surahs = await _surahService.GetAllSurahsAsync();
            return Ok(surahs);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Surah>> GetSurah(int id)
        {
            var surah = await _surahService.GetSurahByIdAsync(id);

            if (surah == null)
            {
                return NotFound();
            }

            return Ok(surah);
        }

        // GET: api/Surah/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SurahDetail>> GetSurahDetail(int id)
        {
            var surah = await _surahService.GetSurahByIdAsync(id);

            if (surah == null)
            {
                return NotFound();
            }
            var ayahs = await _service.GetAyatsBySurahIdAsync(surah.Number);

            var surahDetail = new SurahDetail
            {
                Surah = surah,
                Ayahs = ayahs
            };

            return Ok(surahDetail);
        }
    }
}
