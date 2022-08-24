using Microsoft.AspNetCore.Mvc;
using DAL;

namespace ByteCard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        ConectionDB conection = new ConectionDB();
        
        [HttpGet]
        public IActionResult Get()
        {
            var a = conection.Read("SELECT * FROM Users");
            return Ok(a);
        }
    }
}
