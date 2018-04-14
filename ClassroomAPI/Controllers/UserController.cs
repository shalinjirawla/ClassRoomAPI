using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ClassroomAPI.Repository;
using ClassroomAPI.Models;

namespace ClassroomAPI.Controllers
{
    [EnableCors("AllowOrigin")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository respo)
        {
            userRepository = respo;
        }
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var records = userRepository.GetAllRoles();
            return Ok(records);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var records = userRepository.GetAllUser();
            return Ok(records);
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var record = userRepository.GetUserById(id);
            return Ok(record);
        }
        [HttpPost]
        public IActionResult SaveUser([FromBody]UserModel userModel)
        {
            var result = userRepository.InsertUser(userModel);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Login([FromBody]UserModel model)
        {
            var result = userRepository.LoginUser(model);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var result = userRepository.DeleteUser(id);
            return Ok(result);
        }
    }
}