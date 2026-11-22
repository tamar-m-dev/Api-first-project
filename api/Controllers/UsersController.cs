using api.entiti;
using Microsoft.AspNetCore.Mvc;
using api.service;
namespace api_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<User> users = userService.GetUsers();
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            User user = userService.GetUsersById(id);
            if (user != null)
            {
                Ok(user);
            }
            return NotFound();
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            User createUser = userService.CreateUser(user);
            if (createUser == null)
                return BadRequest("the password is not strong enough");
            return CreatedAtAction(nameof(Get), new { id = createUser.id }, createUser);
        }
        [HttpPost("login")]
        public ActionResult<User> Post([FromBody] logUser logUser)
        {
            User user = userService.LoginUser(logUser);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            try
            {
                userService.ChangeUser(id, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }
    }
}