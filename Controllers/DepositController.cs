using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/account/deposit")]
    public class DepositController : Controller
    {
        [HttpGet]
        public string Deposit()
        {
            return "deposito";
        }
    }
}