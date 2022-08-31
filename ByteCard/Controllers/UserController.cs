using Microsoft.AspNetCore.Mvc;
using BE;
using Services;
using BDE;

namespace ByteCard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpPost]
        public IActionResult Login([FromBody]Users usr)
        {
            try {
                
                bool auth = BDE.Login.login(usr.mail, HashService.hashPass(usr.password));
                return auth ? Ok(true) : BadRequest(false);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
    }
}
