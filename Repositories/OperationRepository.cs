using System.Threading.Tasks;
using Bank.Api.Data;
using Bank.Api.Exceptions;
using Bank.Api.Models.Operations;

namespace Bank.Api.Repositories
{
    public class OperationRepository
    {
        private readonly StoreDataContext _context;
        public OperationRepository(StoreDataContext context)
        {
            _context = context;
        }

        public async Task<AbstractOperation> Find(long id)
        {
            var operation = await _context.AbstractOperation.FindAsync(id);

            if (operation == null)
            {
                throw new OperationNotFoundException(id);
            }

            return operation;
        }
        public async Task Register(AbstractOperation operation)
        {
            operation.SetDescription();
            operation.CalculateRate();

            _context.AbstractOperation.Add(operation);
            await _context.SaveChangesAsync();
        }
    }
}