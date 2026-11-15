using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //How does this controller get the user service? The assignment asks the API to call the Services project: which project references does the API have?
    public class UsersController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    //Is Ok(user) returned here? When the user is found, what should Get return?
                    if (user.id == id)
                        Ok(user);
                }
            }
            return NotFound();
        }
        static string filePath = "User.txt";
        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            int score = Core.EvaluatePassword(user.password).Score;
            if(score < 3)
            {
                return BadRequest("the password is not strong enough");
            }
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.id },user);
        }
        //The assignment asks a login with a wrong password to return 204 NoContent. What does this return when the details are wrong?
        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] logUser user1)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user2 = JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (user2.email == user1.email && user2.password == user1.password)

                        return Ok(user2);
                }
            }
            return NotFound();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        public void Put(int id, [FromBody] User user1)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,JsonSerializer.Serialize(user1));
                System.IO.File.WriteAllText(filePath, text);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
