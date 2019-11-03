namespace Bank.Api.Models.Operations
{
    public class DraftOperation : AbstractOperation
    {
        public override void SetDescription()
        {
            Description = "Saque";
        }
        public override void CalculateRate()
        {
            Rate = (decimal)4;
        }

    }
}