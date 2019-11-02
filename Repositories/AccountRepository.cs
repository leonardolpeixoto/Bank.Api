using System.Threading.Tasks;
using Bank.Api.Data;
using Bank.Api.Exceptions;
using Bank.Api.Models;
using Bank.Api.Models.Validators;
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

        public async Task<Account> Find(long accountNumber)
        {
            return await _context.Accounts.FindAsync(accountNumber);
        }

        public async Task Create(Account account)
        {
            var result = _validator.Validate(account);

            if (!result.IsValid) {
                var errorMessage = JsonConvert.SerializeObject(result.Errors);
                throw new ValidateException(errorMessage);
            }

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        } 
    }
}