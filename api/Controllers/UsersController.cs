using entiti;
using Microsoft.AspNetCore.Mvc;
using service;
namespace Controllers
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

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            User user = await userService.GetUsersById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            User createUser = await userService.CreateUser(user);
            if (createUser == null)
                return BadRequest("the password is not strong enough");
            return CreatedAtAction(nameof(Get), new { id = createUser.Id }, createUser);
        }
        [HttpPost("login")]
        public async Task<ActionResult<User>> Post([FromBody] logUser logUser)
        {
            User user = await userService.LoginUser(logUser);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User user)
        {
            user.Id = id;
            try
            {
                await userService.ChangeUser(id, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }
    }
}