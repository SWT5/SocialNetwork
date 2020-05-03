using SocialNetwork.Models;
using SocialNetwork.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircleController : ControllerBase
    {
        private readonly CircleService _circleService;

        public CircleController(CircleService circleService)
        {
            _circleService = circleService;
        }

        [HttpGet]
        public ActionResult<List<Circle>> Get() =>
            _circleService.Get();

        [HttpGet("{CircleName:length(24)}", Name = "GetCircle")]
        public ActionResult<Circle> Get(string id)
        {
            var circle = _circleService.Get(id);

            if (circle == null)
            {
                return NotFound();
            }

            return circle;
        }

        [HttpPost]
        public ActionResult<Circle> Create(Circle circle)
        {
            _circleService.Create(circle);
            return CreatedAtRoute("GetCircle", new { id = circle.CircleName.ToString() }, circle);
        }

        [HttpPut("{CircleName:length(24)}")]
        public IActionResult Update(string id, Circle circleIn)
        {
            var circle = _circleService.Get(id);

            if (circle == null)
            {
                return NotFound();
            }

            _circleService.Update(id, circleIn);

            return NoContent();
        }

        [HttpDelete("{CircleName:length(24)}")]
        public IActionResult Delete(string id)
        {
            var circle = _circleService.Get(id);

            if (circle == null)
            {
                return NotFound();
            }

            _circleService.Remove(circle.CircleName);

            return NoContent();
        }
    }
}