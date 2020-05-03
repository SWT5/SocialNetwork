using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WallsController : ControllerBase
    {
        private readonly WallService _wallService;

        public WallsController(WallService wallService)
        {
            _wallService = wallService;
        }

        [HttpGet]
        public ActionResult<List<Wall>> Get() =>
            _wallService.Get();

        [HttpGet("{userID:length(24)}", Name = "GetWall")]
        public ActionResult<Wall> Get(string userID)
        {
            var wall = _wallService.Get(userID);

            if (wall== null)
                return NotFound();

            return wall;
        }

        [HttpPost]
        public ActionResult<Wall> Create(Wall wall)
        {
            _wallService.Create(wall);

            return CreatedAtRoute("GetWall", new {userID = wall.UserID.ToString()}, wall);
        }

        [HttpPut("{userID:length(24)}")]
        public IActionResult Update(string userID, Wall wallIn)
        {
            var wall = _wallService.Get(userID);

            if (wall == null)
                return NotFound();

            _wallService.Update(userID, wallIn);
            return NoContent();
        }

        [HttpDelete("{userID:length(24)}")]
        public IActionResult Delete(string userID)
        {
            var wall = _wallService.Get(userID);

            if (wall == null)
                return NotFound();

            _wallService.Remove(wall.UserID);

            return NoContent();

        }


    }
}

