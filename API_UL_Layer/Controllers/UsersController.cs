using Business_Logic_Layer;
using Business_Logic_Layer.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API_UL_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserBLL _UserBLL;

        public UsersController()
        {
            _UserBLL = new UserBLL();
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            UserModel result = await _UserBLL.AddUser(user);

            return result;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LogIn>> Login([FromBody] LogIn model)
        {

            LogIn user = await _UserBLL.Authenticate(model.email!, model.password!);

            if (user == null)
            {
                return BadRequest(new { message = "Invalid email or password" });
            }

            return user;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetUsers()
        {
            var users = await _UserBLL.GetUsers();
            return Ok(users);
        }



    }
}
