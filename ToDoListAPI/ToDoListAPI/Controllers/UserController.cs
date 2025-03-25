using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuario service;

        public UserController(IUsuario service)
        {
            this.service = service;
        }


        [HttpPost("post-user-signup")]
        public void PostSignUp(SignUpDTO user)
        {
            service.PostSignUp(user);
        }

        [HttpPost("post-user-login")]

        public void PostLogIn(LoginDTO user)
        {
            service.PostLogIn(user);
        }



    }
}
