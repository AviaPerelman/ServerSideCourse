using HomeWork2.BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWork2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            User user = new User();
            return user.Read();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public int Post([FromBody] User user)
        {
            int numEffected = user.InsertUser();
            return numEffected;
        }
        // POST api/Users/email/password

        [HttpGet("{email}/{password}")]
        public IActionResult GetLoginUser(string email, int password)
        {
            User user = new User();

            // Call the ReadLoginUser method to check if the user exists
            List<User> userList = user.ReadLoginUser(email, password);

            // Check if any user was found with the provided credentials
            if (userList.Count > 0)
            {
                // User found, login successful
                return Ok(userList); // Return the user details
            }
            else
            {
                // No user found, login unsuccessful
                return NotFound(); // Return a 404 Not Found status code
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
