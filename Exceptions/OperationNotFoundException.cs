namespace Bank.Api.Exceptions
{
    public class OperationNotFoundException : NotFoundException
    {
        public OperationNotFoundException(long id) : base($"Operação {id} não foi encontrada.")
        { }

    }
}