using BlazorTicketServerApp.Database;
using BlazorTicketServerApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace BlazorTicketServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsesController : ControllerBase
    {
        private readonly Repository repo;
        public ResponsesController(AppDbContext dbContext)
        {
            repo = new(dbContext);
        }
        public static List<ResponseModel> Responses { get; set; } = new()
        {
            new ResponseModel()
            {
                Id = 1,
                Response = "Just make a controller!",
                SubmittedBy = "Otto",
                TicketId = 1
            },
            new ResponseModel()
            {
                Id = 2,
                Response = "Elias, shes at the register!",
                SubmittedBy = "Fredrik",
                TicketId = 2
            },
            new ResponseModel()
            {
                Id = 3,
                Response = "Change Settings.json",
                SubmittedBy = "Calle",
                TicketId = 3
            },
            new ResponseModel()
            {
                Id = 4,
                Response = "hejhejhejj",
                SubmittedBy = "FreddeBigBoi",
                TicketId = 3
            }
        };

        [HttpGet("GetAll")]
        public ActionResult<List<ResponseModel>> GetResponses()
        {
            return Ok(Responses);
        }

        [HttpGet("{id}")]
        public ActionResult<List<ResponseModel>> GetResponsesByTicketId(int id)
        {
            var filteredResponse = Responses.Where(Response => Response.TicketId == id).ToList();
            return Ok(filteredResponse);
        }

        [HttpPost]
        public async Task<IActionResult> PostResponseAsync(ResponseModel response)
        {
            if (response.Response == null || response.SubmittedBy == null)
            {
                return BadRequest("Response or user is empty!");
            }
            await repo.AddResponseAsync(response);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteResponseAsync(int id)
        {
            await repo.RemoveResponseAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateResponse(ResponseModel response)
        {
            await repo.UpdateResponseAsync(response);
            return Ok();
        }
    }
}
