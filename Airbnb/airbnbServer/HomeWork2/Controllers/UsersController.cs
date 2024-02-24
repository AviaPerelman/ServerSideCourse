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

        //[HttpGet("{email}/{password}")]
        //public IActionResult GetLoginUser(string email, int password)
        //{
        //    User user = new User();

        //    // Call the ReadLoginUser method to check if the user exists
        //    List<User> userList = user.ReadLoginUser(email, password);

        //    // Check if any user was found with the provided credentials
        //    if (userList.Count > 0)
        //    {
        //        // User found, login successful
        //        return Ok(userList); // Return the user details
        //    }
        //    else
        //    {
        //        // No user found, login unsuccessful
        //        return NotFound(); // Return a 404 Not Found status code
        //    }
        //}


        [HttpPost("login")]
        public ActionResult Login(User user)
        {
            
            // Validate user credentials
            User authenticatedUser = user.ValidateUser(user.Email, user.Password);

            if (authenticatedUser != null)
            {
                // Return the authenticated user
                return Ok(authenticatedUser);
            }
            else
            {
                // Return 404 if user does not exist or credentials are invalid
                return NotFound("User not found or invalid credentials");
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                // Call the Update method of the User class to update user information
                User updatedUser = user.Update(user.Email, user.FirstName, user.FamilyName, user.Password);

                if (updatedUser != null)
                {
                    // If the update operation was successful, return the updated user object
                    return Ok(updatedUser);
                }
                else
                {
                    // If the update operation failed (e.g., user not found), return 404 Not Found
                    return NotFound("User with the specified email was not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can use a logging framework like Serilog or log4net to log exceptions

                // Return an error response
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
