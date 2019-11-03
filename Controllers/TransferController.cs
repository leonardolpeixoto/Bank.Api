using System.Threading.Tasks;
using Bank.Api.Models.Operations;
using Bank.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/account/transfer")]
    public class TransferController : Controller
    {
        private readonly OperationRepository _operationRepository;
        private readonly AccountRepository _repository;
        public TransferController(OperationRepository operationRepository, AccountRepository repository)
        {
            _operationRepository = operationRepository;
            _repository = repository;
        }

        [HttpPost]
        public async Task Transfer([FromBody]TransferOperation operation)
        {
            await _repository.Decrement(operation.AccountNumber, operation.Amount);
            await _repository.Decrement(operation.AccountNumber, operation.Rate);

            await _repository.Increment(operation.AccountToNumber, operation.Amount);

            await _operationRepository.Register(operation);
            Ok();
        }
    }
}