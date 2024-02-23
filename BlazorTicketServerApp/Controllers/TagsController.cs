using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace BlazorTicketServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
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


        [HttpGet]
        public ActionResult<List<ResponseModel>> GetTags()
        {
            return Ok(Tags);
        }

    }
}
