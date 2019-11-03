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

        [HttpGet("{id}")]
        public async Task<ActionResult<AbstractOperation>> Get(long id)
        {
            return await _operationRepository.Find(id);
        }

        [HttpPost]
        public async Task<ActionResult<AbstractOperation>> Daft([FromBody]DraftOperation draft)
        {
            await _repository.Decrement(draft.AccountNumber, draft.Amount);
            await _repository.Decrement(draft.AccountNumber, draft.Rate);

            return await _operationRepository.Register(draft);
        }
    }
}