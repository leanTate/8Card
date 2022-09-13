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
        [HttpPost("/transaction")]
        public IActionResult transaction(transactionDto request)
        {
            var reqToken = JWT.ReadToken(request.token);
            Validator jwtvalidator = new Validator();
            Actions actions = new Actions();
            var validate = jwtvalidator.validateToken(reqToken);
            return validate == true ? Ok(actions.Transaction(request)) : BadRequest("Invalid Token");
        }
    }
}
