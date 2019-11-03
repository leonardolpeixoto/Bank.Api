namespace Bank.Api.Models.Operations
{
    public class TransferOperation : AbstractOperation
    {
        public long AccountToNumber { get; set; }
        public  override void SetDescription() {
           Description = "Trasnferência"; 
        }
        public override void CalculateRate()
        {
            Rate = (decimal) 1;
        }

    }
}