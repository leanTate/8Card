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
        [HttpPost]
        public IActionResult Login([FromBody] loginSchemma usr)
        {
            try {
                string hashpass = HashService.hashPass(usr.password);
                UserDAO userDAO = new UserDAO();
                User response = userDAO.Login(usr.mail);
                Console.WriteLine(response.mail);
                return response.mail ==usr.mail && response.password == hashpass? Ok(true) : BadRequest(false);
                
            }
            catch(Exception ex){
                return BadRequest(ex);
            }
        }
    }
}
