using API_Calculadora.Controllers;
using API_RestFull.Data.VO;
using API_RestFull.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_RestFull.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SacolaController : ControllerBase
    {
        private readonly ILogger<SacolaController> _logger;
        private ISacolaService _sacolaService;

        public SacolaController(ILogger<SacolaController> logger, ISacolaService sacolaService)
        {
            _logger = logger;
            _sacolaService = sacolaService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_sacolaService.FindAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var Sacola = _sacolaService.FindByID(Id);
            if (Sacola != null)
            {
                return Ok(Sacola);
            }
            return BadRequest("ID inválido");
        }

        //Create
        [HttpPost]
        public IActionResult Post([FromBody] SacolaVO sacola)
        {
            if (sacola == null)
            {
                return NotFound();
            }
            return Ok(_sacolaService.Create(sacola));
        }
        //Update
        [HttpPut]
        public IActionResult Put([FromBody] SacolaVO sacola)
        {
            if (sacola == null)
            {
                return NotFound();
            }
            return Ok(_sacolaService.Update(sacola));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            _sacolaService.Delete(id);
            return NoContent();
        }
    }
}
