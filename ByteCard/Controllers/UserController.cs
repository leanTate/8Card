using Microsoft.AspNetCore.Mvc;
using BE;
using Services;
using DAL;

namespace ByteCard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpPost("/login")]
        public IActionResult Login([FromBody] loginSchemma usr)
        {
            string hashpass = HashService.hashPass(usr.password);
            UserDAO userDAO = new UserDAO();
            User response = userDAO.Login(usr.mail);
            bool log = response.mail == usr.mail && response.password == hashpass ? session.login(response) : false;
            return log ? Ok(true) : BadRequest(false); 
            
        }
        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            return Ok(session.logout());
        }
    }
}
