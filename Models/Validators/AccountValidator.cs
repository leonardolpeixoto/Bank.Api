using FluentValidation;

namespace Bank.Api.Models.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(account => account.Balance).NotNull().GreaterThanOrEqualTo(0).WithMessage("Saldo não pode ser menor que zero");
        }
    }
}