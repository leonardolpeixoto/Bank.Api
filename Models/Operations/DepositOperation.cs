using System;

namespace Bank.Api.Models.Operations
{
    public class DepositOperation : AbstractOperation
    {
        public override void CalculateRate()
        {
            Rate = Amount * (decimal)0.01;
        }

    }
}