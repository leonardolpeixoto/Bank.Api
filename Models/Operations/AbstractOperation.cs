using System;

namespace Bank.Api.Models.Operations
{
    public abstract class AbstractOperation
    {
        public long Id { get; set; }
        public Account Account { get; set; }
        public string Description { get; set; }
        public string OperationType { get; set; }
        public long AccountNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public abstract void CalculateRate();
    }
}