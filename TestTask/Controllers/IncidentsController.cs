using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentsService incidentsService;

        public IncidentsController(IIncidentsService incidentsService)
        {
            this.incidentsService = incidentsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await incidentsService.GetAll());
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await incidentsService.Get(name));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIncidentDto model)
        {
            await incidentsService.Create(model);
            return Ok();
        }
    }
}
