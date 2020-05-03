using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork.Controllers
{
    public class FeedController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class BooksController : ControllerBase
        {
            private readonly FeedService _feedService;

            public BooksController(FeedService feedService)
            {
                _feedService = feedService;
            }

            [HttpGet]
            public ActionResult<List<Feed>> Get() =>
                _feedService.Get();

            [HttpGet("{id:length(24)}", Name = "GetBook")]
            public ActionResult<Feed> Get(string id)
            {
                var feed = _feedService.Get(id);

                if (feed == null)
                {
                    return NotFound();
                }

                return feed;
            }

            [HttpPost]
            public ActionResult<Feed> Create(Feed feed)
            {
                _feedService.Create(feed);

                return CreatedAtRoute("GetFeed", new { id = feed.FeedID.ToString() }, feed);
            }

            [HttpPut("{id:length(24)}")]
            public IActionResult Update(string FeedId, Feed feedIn)
            {
                var feed = _feedService.Get(FeedId);

                if (feed == null)
                {
                    return NotFound();
                }

                _feedService.Update(FeedId, feedIn);

                return NoContent();
            }

            [HttpDelete("{id:length(24)}")]
            public IActionResult Delete(string id)
            {
                var feed = _feedService.Get(id);

                if (feed == null)
                {
                    return NotFound();
                }

                _feedService.Remove(feed.FeedID);

                return NoContent();
            }
        }
    }
}
