using BlazorTicketServerApp.Database;
using BlazorTicketServerApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace BlazorTicketServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly Repository repo;
        public TagsController(AppDbContext dbContext)
        {
            repo = new(dbContext);
        }
        public static List<TagModel> Tags { get; set; } = new()
        {
            new TagModel()
            {
                Id = 1,
                Name = "CSharp"
            },
            new TagModel()
            {
                Id = 2,
                Name = "Algorithms"
            },
            new TagModel()
            {
                Id = 3,
                Name = "MachineLearning"
            }
        };


        [HttpGet("GetAllTags")]
        public async Task<ActionResult<List<TagModel>>> GetTags()
        {
            List<TagModel> tags = await repo.GetAllTagsAsync();
            if (tags != null)
            {
                return Ok(tags);
            }
            return BadRequest();
        }

        [HttpGet("GetTagById/{id}")]
        public async Task<IActionResult> GetTagById(int id)
        {
            TagModel tag = await repo.GetTagByIdAsync(id);
            if (tag != null)
            {
                return Ok(tag);
            }
            return BadRequest();
        }

        [HttpPost]
        // vet inte om denna behövs
        public async Task<IActionResult> PostTagAsync(TagModel tag)
        {
            if (tag.Name == null)
            {
                return BadRequest("Tag must contain a title!");
            }

            await repo.AddTagAsync(tag);
            return Ok(tag);
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteTicketAsync(int id)
        //{
        //    await repo.RemoveTicketAsync(id);
        //    return Ok();
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateTicket(TicketModel ticket)
        //{
        //    await repo.UpdateTicket(ticket);
        //    return Ok();
        //}
    }
}
