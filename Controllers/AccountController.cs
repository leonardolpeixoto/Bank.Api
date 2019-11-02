using System.Threading.Tasks;
using Bank.Api.Models;
using Bank.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly AccountRepository _repository;

        public AccountController(AccountRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Account>> Create([FromBody]Account account)
        {
            await _repository.Create(account);
            return CreatedAtAction(nameof(GetAccount), new { accountNumber = account.AccountNumber }, account);
        }

        [HttpGet("{accountNumber}")]
        public async Task<ActionResult<Account>> GetAccount(long accountNumber) 
        {
            return await _repository.Find(accountNumber);
        }
    }
}