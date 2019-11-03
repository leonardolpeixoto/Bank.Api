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

        [HttpPost]
        public async Task Deposit([FromBody]DepositOperation operation)
        {
            await _repository.Increment(operation.AccountNumber, operation.Amount);
            await _repository.Decrement(operation.AccountNumber, operation.Rate);

            await _operationRepository.Register(operation);

            Ok();
        }
    }
}