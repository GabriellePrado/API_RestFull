using API_Calculadora.Model;
using API_Calculadora.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_Calculadora.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_personService.FindAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var person = _personService.FindByID(Id);
                if (person != null)
            {
                return Ok(person);
            }
            return BadRequest("ID inválido");
        }

        //Create
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if(person == null)
            {
                return NotFound();
            }
            return Ok(_personService.Create(person));
        }
        //Update
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
            {
                return NotFound();
            }
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            var person = _personService.FindByID(id);
            if (person.Id == id)
            {
                _personService.Delete(id);
            }
            return BadRequest("Id inválido");
        }
    }
}
