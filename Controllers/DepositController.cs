using System.Threading.Tasks;
using Bank.Api.Models.Operations;
using Bank.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/account/deposit")]
    public class DepositController : Controller
    {
        private readonly OperationRepository _operationRepository;
        private readonly AccountRepository _repository;
        public DepositController(OperationRepository operationRepository, AccountRepository repository)
        {
            _operationRepository = operationRepository;
            _repository = repository;
        }

        [HttpPut]
        public async Task<ActionResult<AbstractOperation>> Deposit([FromBody]DepositOperation deposit)
        {
            await _repository.Increment(deposit.AccountNumber, deposit.Amount);
            await _repository.Decrement(deposit.AccountNumber, deposit.Rate);

            return await _operationRepository.Register(deposit);
        }
    }
}