using BE.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using DAL;
using Security;

namespace ByteCard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult getData([FromBody] string token)
        {
            var reqToken = JWT.ReadToken(token);
            Validator jwtvalidator = new Validator();
            Actions actions = new Actions();
            var validate = jwtvalidator.validateToken(reqToken);
            return validate == true ? Ok(actions.getData(reqToken)) : BadRequest();
        }
        [HttpPost("/transaction")]
        public IActionResult transaction(transactionDto request)
        {
            var reqToken = JWT.ReadToken(request.token);
            Validator jwtvalidator = new Validator();
            Actions actions = new Actions();
            var validate = jwtvalidator.validateToken(reqToken);
            return validate == true && request.cash>=request.amount ? Ok(actions.Transaction(request)) : BadRequest("Transaction Failed");
        }
        [HttpPost("/deposit")]
        public IActionResult Deposit(DepositDto request)
        {
            Actions actions = new Actions();
            return actions.Deposit(request) == true? Ok("deposit is Ok") : BadRequest("Deposit Failed");
        }
    }
}
