namespace Bank.Api.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
    }
}