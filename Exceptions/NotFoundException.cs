using System;

namespace Bank.Api.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string erroMessage) : base(erroMessage)
        { }
    }
}