using Microsoft.AspNetCore.Mvc;
using BE;
using Security;
using DAL;
using BE.entites;
using BE.DTO;

namespace ByteCard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {

        [HttpPost("/register")]
        public IActionResult Register([FromBody] RegisterDto usr)
        {
            string hashpass = HashService.hashPass(usr.password);
            UserDAO userDAO = new UserDAO();
            usr.password = hashpass;
            return userDAO.Register(usr) ? Ok(true) : BadRequest(false);
        }
        [HttpPost("/login")]
        public IActionResult Login([FromBody] LoginDto request)
        {
            string hashpass = HashService.hashPass(request.password);
            UserDAO userDAO = new UserDAO();
            User SQLresponse = userDAO.Login(request.mail);
            string token = JWT.CreateToken(SQLresponse);
            SQLresponse.token = token;
            UserDto user = new UserDto();
            user.mail = SQLresponse.mail;
            user.userName = SQLresponse.userName;
            user.lastName = SQLresponse.lastName;
            user.celphone = SQLresponse.celphone;
            user.dni = SQLresponse.dni;
            user.token = token;
            bool log = SQLresponse.mail == request.mail && SQLresponse.password == hashpass ? true : false;
            return log ? Ok(user) : BadRequest(false); 
        }
    }
}
