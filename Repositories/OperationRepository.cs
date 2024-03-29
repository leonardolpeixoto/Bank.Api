using System.Collections.Generic;
using System.Threading.Tasks;
using Bank.Api.Data;
using Bank.Api.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<AbstractOperation>> FindAll(long accountNumber)
        {
            return await _context
                .AbstractOperation
                .Where(operation => operation.AccountNumber.Equals(accountNumber))
                .ToListAsync();
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