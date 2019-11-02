namespace Bank.Api.Exceptions
{
    public class AccountNotFoundException : NotFoundException
    {
        public AccountNotFoundException(long accontNumber) : base($"A conta {accontNumber} não existe.")
        { }

    }
}