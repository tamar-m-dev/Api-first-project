using Microsoft.AspNetCore.Mvc;
using service;
namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private IPasswordService PS;
        public PasswordsController(IPasswordService PS)
        {
            this.PS = PS;
        }
        [HttpPost]
        public ActionResult<int> Post([FromBody] string password)
        {
            int score = PS.CheckPassword(password);
            return Ok(score);
        }
    }
}
