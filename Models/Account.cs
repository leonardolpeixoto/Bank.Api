using System.Collections.Generic;
using Bank.Api.Exceptions;
using Bank.Api.Models.Operations;

namespace Bank.Api.Models
{
    public class Account
    {
        public long AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public List<AbstractOperation> Operations { get; set; }

        public void ValidateAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ValidateException("Amount deve ser maior que zero");
            }
        }
        public void Increment(decimal amount)
        {
            ValidateAmount(amount);

            Balance += amount;
        }

        public void Decrement(decimal amount)
        {
            ValidateAmount(amount);

            Balance -= amount;
        }
    }
}