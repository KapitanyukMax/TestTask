using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService contactsService;

        public ContactsController(IContactsService contactsService)
        {
            this.contactsService = contactsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await contactsService.GetAll());
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            return Ok(await contactsService.Get(email));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactDto model)
        {
            await contactsService.Create(model);
            return Ok();
        }
    }
}
