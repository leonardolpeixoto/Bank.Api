using System;

namespace Bank.Api.Exceptions
{
    public class ValidateException : ArgumentException
    {
        public ValidateException(string errorMessage) : base(errorMessage)
        { }
    }
}