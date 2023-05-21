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
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private IProdutoService _produtoService;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService produtoService)
        {
            _logger = logger;
            _produtoService = produtoService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_produtoService.FindAll());
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var Produto = _produtoService.FindByID(Id);
            if (Produto != null)
            {
                return Ok(Produto);
            }
            return BadRequest("ID inválido");
        }
        [HttpPost]
        public IActionResult Post([FromBody] ProdutoVO produto)
        {
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(_produtoService.Create(produto));
        }
        [HttpPut]
        public IActionResult Put([FromBody] ProdutoVO produto)
        {
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(_produtoService.Update(produto));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            _produtoService.Delete(id);
            return NoContent();
        }
    }
}
