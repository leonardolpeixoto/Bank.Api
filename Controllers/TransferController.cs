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

        [HttpPut]
        public async Task<ActionResult<AbstractOperation>> Daft([FromBody]TransferOperation transfer)
        {
            await _repository.Decrement(transfer.AccountNumber, transfer.Amount);
            await _repository.Decrement(transfer.AccountNumber, transfer.Rate);

            await _repository.Increment(transfer.AccountToNumber, transfer.Amount);

            return await _operationRepository.Register(transfer);
        }
    }
}