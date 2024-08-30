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

        // GET: api/para
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Para>>> GetAllParas()
        {
            var paras = await _paraService.GetAllParasAsync();
            return Ok(paras);
        }

        // POST: api/para
        [HttpPost]
        public async Task<ActionResult<Para>> AddPara(Para para)
        {
            var createdPara = await _paraService.AddParaAsync(para);
            return CreatedAtAction(nameof(GetParaDetail), new { id = createdPara.ParaID }, createdPara);
        }

        // PUT: api/para/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePara(int id, Para para)
        {
            if (id != para.ParaID)
            {
                return BadRequest("Para ID mismatch");
            }

            var updatedPara = await _paraService.UpdateParaAsync(id, para);
            if (updatedPara == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE: api/para/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePara(int id)
        {
            await _paraService.DeleteParaAsync(id);

            return NoContent();
        }

        [HttpPost("bulk")]
        public async Task<ActionResult<IEnumerable<Para>>> AddParasBulk(List<Para> paras)
        {
            if (paras == null || !paras.Any())
            {
                return BadRequest("The list of Paras is null or empty.");
            }

            foreach (var para in paras)
            {
                await _paraService.AddParaAsync(para);
            }

            return Ok();
        }
    }
}
