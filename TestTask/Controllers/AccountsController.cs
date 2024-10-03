using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await accountsService.GetAll());
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await accountsService.Get(name));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountDto model)
        {
            await accountsService.Create(model);
            return Ok();
        }
    }
}
