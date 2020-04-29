using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Authentication;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _userService.Get();

        [HttpGet("{userName:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string userName)
        {
            var user = _userService.Get(userName);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new {userName = user.UserName.ToString()}, user);
        }

        [HttpPut("{userName:length(24)}")]
        public IActionResult Update(string userName, User userIn)
        {
            var user = _userService.Get(userName);

            if (user == null)
                return NotFound();

            _userService.Update(userName, userIn);
            return NoContent();
        }

        [HttpDelete("{userName:length(24)}")]
        public IActionResult Delete(string userName)
        {
            var user = _userService.Get(userName);

            if (user == null)
                return NotFound();

            _userService.Remove(user.UserName);

            return NoContent();

        }
    }
}