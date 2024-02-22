using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace BlazorTicketServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTagsController : ControllerBase
    {

        public static List<TicketTag> TicketTags { get; set; } = new()
        {
            new TicketTag()
            {
                TagId = 1,
                TicketId = 1
            },
            new TicketTag()
            {
                TagId = 2,
                TicketId = 2
            },
            new TicketTag()
            {
                TagId = 3,
                TicketId = 3
            },
        };

        [HttpGet]
        public ActionResult<List<ResponseModel>> GetTicketTags()
        {
            return Ok(TicketTags);
        }
    }
}
