using System.Collections.Generic;
using System.Threading.Tasks;
using Bank.Api.Models.Operations;
using Bank.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/account/extract")]
    public class ExtractController : Controller
    {
        private readonly OperationRepository _repository;
        public ExtractController(OperationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{accountNumber}")]
        public async Task<ActionResult<List<AbstractOperation>>> Extract(long accountNumber)
        {
            return await _repository.FindAll(accountNumber);
        }
    }
}