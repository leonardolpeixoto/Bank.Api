using System.Threading.Tasks;
using Bank.Api.Models.Operations;
using Bank.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/account/draft")]
    public class DraftController : Controller
    {
        private readonly OperationRepository _operationRepository;
        private readonly AccountRepository _repository;
        public DraftController(OperationRepository operationRepository, AccountRepository repository)
        {
            _operationRepository = operationRepository;
            _repository = repository;
        }

        [HttpPost]
        public async Task Daft([FromBody]DraftOperation operation)
        {
            await _repository.Decrement(operation.AccountNumber, operation.Amount);
            await _repository.Decrement(operation.AccountNumber, operation.Rate);

            await _operationRepository.Register(operation);

            Ok();
        }
    }
}