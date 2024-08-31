using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuranApi.Interfaces;
using QuranApi.Models;

namespace QuranApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParaController : ControllerBase
    {
        private readonly ISurahService _surahService;
        private readonly ISurahAyatService _service;
        private readonly IParaService _paraService;

        public ParaController(ISurahService surahService, ISurahAyatService service, IParaService paraService)
        {
            _surahService = surahService;
            _service = service;
            _paraService = paraService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParaDetail>> GetParaDetail(int id)
        {
            var para = await _paraService.GetParaByIdAsync(id);

            if (para == null)
            {
                return NotFound();
            }

            var ayahs = await _service.GetAyatsByParaIdAsync(para.ParaID);

            var paraDetail = new ParaDetail
            {
                Para = para,
                Ayahs = ayahs
            };

            return Ok(paraDetail);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<ParaDetail>> GetPara(int id)
        {
            var para = await _paraService.GetParaByIdAsync(id);

            if (para == null)
            {
                return NotFound();
            }

            return Ok(para);
        }

        // GET: api/para
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Para>>> GetAllParas()
        {
            var paras = await _paraService.GetAllParasAsync();
            return Ok(paras);
        }
    }
}
