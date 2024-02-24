using BlazorTicketServerApp.Database;
using BlazorTicketServerApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace BlazorTicketServerApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketsController : ControllerBase
	{
		private readonly Repository repo;
		public TicketsController(AppDbContext dbContext)
		{
			repo = new(dbContext);
		}
		public static List<TicketModel> Tickets { get; set; } = new()
		{
			new TicketModel()
			{
				Id = 1,
				Title = "Cant find controller",
				Description = "lorem 20",
				SubmittedBy = "Calle",
				IsResolved = false,
				TicketTags = new List<TicketTag>
				{
					new TicketTag { TagId = (int)Tag.CSharp}
				},
				Responses = new List<ResponseModel>
				{
					new ResponseModel { Response = "test", SubmittedBy = "fredrik" }
				}
			},
			new TicketModel()
			{
				Id = 2,
				Title = "Cant find my mom in mall",
				Description = "lorem 25",
				SubmittedBy = "Elias",
				IsResolved = false,
			},
			new TicketModel()
			{
				Id = 3,
				Title = "Cant connect connection string",
				Description = "lorem 30",
				SubmittedBy = "Otto",
				IsResolved = false,
			},
		};

    [HttpGet("GetAllTickets")]
    public async Task<ActionResult<List<TicketModel>>> GetTickets()
    {
        List<TicketModel> tickets = await repo.GetAllTicketsAsync();
        if (tickets != null)
        {
            return Ok(tickets);
        }
        return BadRequest();
    }

    [HttpGet("GetTicketById/{id}")]
    public async Task<IActionResult> GetTicketById(int id)
    {
        TicketModel newTicket = await repo.GetTicketByIdAsync(id);
        if (newTicket != null)
        {
            return Ok(newTicket);
        }
        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> PostTicketAsync(TicketModel ticket)
    {
        if (ticket.Title == null || ticket.Description == null)
        {
            return BadRequest("Ticket must contain title and description!");
        }
			await repo.AddTicketAsync(ticket);
			return Ok(ticket);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteTicketAsync(int id)
		{
			await repo.RemoveTicketAsync(id);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> UpdateTicket(TicketModel ticket)
		{
			await repo.UpdateTicket(ticket);
			return Ok();
		}


		//[HttpPost("PostResponse")]
		//public async Task<IActionResult> PostTicketAsync(ResponseModel response)
		//{
		//}

		// TagModel
		//public int Id { get; set; }
		//public string Name { get; set; } // Exempel: "CSharp", "JavaScript"
		//public List<TicketTag> TicketTags { get; set; } = new List<TicketTag>();

		//ResponseModel
		//public int Id { get; set; }
		//public string Response { get; set; }
		//public string SubmittedBy { get; set; }
		//public int TicketId { get; set; }
		//public TicketModel Ticket { get; set; }

		//TicketModel
		//public int Id { get; set; }
		//public string Title { get; set; }
		//public string Description { get; set; }
		//public string SubmittedBy { get; set; } // Användarnamn eller e-post
		//public bool IsResolved { get; set; }

	}
}

