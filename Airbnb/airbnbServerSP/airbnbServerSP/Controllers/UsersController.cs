using Microsoft.AspNetCore.Mvc;
using HomeWork2.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeWork2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            User user = new User(); 
            return user.Read();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //POST 

        [HttpPost]
        public int Post([FromBody] User user)
        {

            return user.Insert();
        }

        // POST api/<UsersController>
        [HttpPost]
        [Route("login")]
        public ActionResult Login(User user)
        {

            User authenticatedUser = user.Login(user.Email, user.Password);

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

        // PUT api/<UsersController>/5
        [HttpPut("update")]
        public User Put([FromBody] User user)
        {
            return user.Update();
        }

        [HttpPut]
        [Route("isActive")]
        public int updateActive([FromBody] User u)
        {
            return u.UpdateIsActive();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("delete")]
        public int Delete([FromBody] string email)
        {
            User user = new User();
            return user.Delete(email);
        }

       
    }
}
