using System;
using Bank.Api.Models.Operations;
using Bank.Api.Repositories;

namespace Bank.Api.Services
{
    public class OperationService
    {
        private readonly AccountRepository _repository;
        public OperationService(AccountRepository repository)
        {
            _repository = repository;
        }

        public AbstractOperation Exec(AbstractOperation operation)
        {
            operation.Date = DateTime.Now;

            // if (operation.ToAccountNumber == 0) {
            //     operation.ToAccountNumber = operation.FromAccountNumber;
            // }

            operation.CalculateRate();

            return operation;
        }
    }
}