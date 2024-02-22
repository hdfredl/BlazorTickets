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
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext dbContext)
        {
            _context = dbContext;

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

        [HttpGet]
        public ActionResult<List<TicketModel>> GetTickets()
        {
            return Ok(Tickets);
        }

        [HttpPost]
        public async Task<IActionResult> PostTicketAsync(TicketModel ticket)
        {

            Repository repo = new Repository(_context);

            if (ticket != null)
            {
                TicketModel model = new TicketModel()
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Description = ticket.Description,
                    SubmittedBy = ticket.SubmittedBy,
                    IsResolved = ticket.IsResolved,
                };
            };
            await repo.AddTicketAsync(ticket);
            _context.SaveChanges();
            return Ok(ticket);
        }
    }


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

