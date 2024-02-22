using Shared.Models;

namespace Shared;

public static class DummyData
{
	private static List<TicketModel> tickets;

	static DummyData()
	{
		tickets = new List<TicketModel>
		{
			new TicketModel
			{
				Title = "ticket 1",
				Description = "problem med start.",
				SubmittedBy = "user1",
				IsResolved = false,
				TicketTags = new List<TicketTag>
				{
					new TicketTag { TagId = (int)Tag.CSharp },
					new TicketTag { TagId = (int)Tag.Blazor }
				},
				Responses = new List<ResponseModel>
			{
					new ResponseModel { Response = "test", SubmittedBy = "fredrik" }
			}

			},

			new TicketModel
			{
				Title = "ticket 2",
				Description = "problem med databasen.",
				SubmittedBy = "user2",
				IsResolved = false,
				TicketTags = new List<TicketTag>
				{
					new TicketTag { TagId = (int)Tag.CSharp },
					new TicketTag { TagId = (int)Tag.Blazor }
				},
				Responses = new List<ResponseModel>
				{
					new ResponseModel { Response = "hehe", SubmittedBy = "fredrik" }
				}
			},
		};
	}
}

