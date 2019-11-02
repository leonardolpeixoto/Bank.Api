using Bank.Api.Models.Operations;
using Bank.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/account/deposit")]
    public class DepositController : Controller
    {
        private readonly OperationService _service;
        public DepositController(OperationService service)
        {
            _service = service;
        }

        [HttpPut]
        public DepositOperation Deposit([FromBody]DepositOperation deposit)
        {
            return (DepositOperation) _service.Exec(deposit);
        }
    }
}