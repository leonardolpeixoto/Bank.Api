namespace Bank.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Account Account { get; set; }
        public string Password { get; set; }
    }
}