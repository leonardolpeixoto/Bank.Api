using System.Threading.Tasks;
using Bank.Api.Data;
using Bank.Api.Exceptions;
using Bank.Api.Models;
using Bank.Api.Models.Validators;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Bank.Api.Repositories
{
    public class AccountRepository
    {
        private readonly StoreDataContext _context;
        private readonly AccountValidator _validator;
        public AccountRepository(StoreDataContext context, AccountValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public void Validate(Account account)
        {
            var result = _validator.Validate(account);

            if (!result.IsValid)
            {
                var errorMessage = JsonConvert.SerializeObject(result.Errors);
                throw new ValidateException(errorMessage);
            }
        }

        public async Task<Account> Find(long accountNumber)
        {
            var account = await _context.Accounts.FindAsync(accountNumber);

            if (account == null)
            {
                throw new AccountNotFoundException(accountNumber);
            }

            return account;
        }

        public async Task Create(Account account)
        {
            Validate(account);

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Account account)
        {
            Validate(account);
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Increment(long accountNumber, decimal value)
        {
            var account = await Find(accountNumber);

            account.Increment(value);
            
            await Update(account);
        }

        public async Task Decrement(long accountNumber, decimal value)
        {
            var account = await Find(accountNumber);

            account.Decrement(value);
            
            await Update(account);
        }
        
    }
}