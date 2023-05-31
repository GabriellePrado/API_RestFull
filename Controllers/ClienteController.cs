using API_RestFull.Data.VO;
using API_RestFull.Hypermedia.Filters;
using API_RestFull.Model;
using API_RestFull.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_Calculadora.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly ILogger<ClienteController> _logger;
        private IClienteService _clienteService;

        public ClienteController(ILogger<ClienteController> logger, IClienteService ClienteService)
        {
            _logger = logger;
            _clienteService = ClienteService;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {

            return Ok(_clienteService.FindAll());
        }

        [HttpGet("{Id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int Id)
        {
            var Cliente = _clienteService.FindByID(Id);
            if (Cliente != null)
            {
                return Ok(Cliente);
            }
            return BadRequest("ID inválido");
        }

        //Create
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] ClienteVO Cliente)
        {
            if (Cliente == null)
            {
                return NotFound();
            }
            return Ok(_clienteService.Create(Cliente));
        }
        //Update
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] ClienteVO Cliente)
        {
            if (Cliente == null)
            {
                return NotFound();
            }
            return Ok(_clienteService.Update(Cliente));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
                _clienteService.Delete(id);
                return NoContent();
        }
    }
}
