using System;
using System.Collections.Generic;
using Bank.Api.Models.Operations;

namespace Bank.Api.Models
{
    public class Account
    {
        public long AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public List<AbstractOperation> Operations { get; set; }

         public void Increment(decimal value)
        {
            Balance += Math.Abs(value);
        }

        public void Decrement(decimal value)
        {
            Balance -= Math.Abs(value);
        }
    }
}