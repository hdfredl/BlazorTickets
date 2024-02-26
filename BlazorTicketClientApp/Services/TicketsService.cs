using BlazorTicketClientApp.Models;
using Newtonsoft.Json;
using Shared.Models;
using System.Net.Http.Json;

namespace BlazorTicketClientApp.Services
{
	public class TicketsService : ITicketsService
	{
		public HttpClient Client { get; set; } = new()
		{
			BaseAddress = new Uri("https://localhost:7034/api/")
		};

		public async Task<List<TicketViewModel>> GetAllAsync()
		{
			var response = await Client.GetAsync("Tickets/GetAllTickets");
			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();

				List<TicketViewModel> tickets = JsonConvert.DeserializeObject<List<TicketViewModel>>(jsonResponse);

				if (tickets != null)
				{
					// se om det finns responses,Gå igenom alla tickets, hämta o ändra till true om finns eller falase om ej
					foreach (var ticket in tickets)
					{
						if (ticket.Responses != null && ticket.Responses.Any())
						{
							ticket.IsResolved = true;

						}
						else
						{
							ticket.IsResolved = false;
						}
						Console.WriteLine($"Ticket Id: {ticket.Id}, Initial IsResolved: {ticket.IsResolved}, Responses Count: {ticket.Responses}");
					}

					return tickets.OrderByDescending(t => t.Id).ToList();
				}

				throw new JsonException();
			}
			throw new HttpRequestException();
		}

		public async Task<TicketViewModel> GetTicketByIdAsync(int id)
		{
			// Hämta från API
			var response = await Client.GetAsync($"Tickets/GetTicketById/{id}");
			if (response.IsSuccessStatusCode)
			{
				//Läs Json
				string jsonResponse = await response.Content.ReadAsStringAsync();
				//Deserialisera
				TicketViewModel ticket = JsonConvert.DeserializeObject<TicketViewModel>(jsonResponse);

				if (ticket != null)
				{
					return ticket;
				}

				throw new JsonException();
			}
			throw new HttpRequestException();
		}

		public async Task PostTicketAsync(TicketViewModel ticket)
		{
			TicketModel ticketToPost = new()
			{
				Title = ticket.Title,
				Description = ticket.Description,
				SubmittedBy = ticket.SubtmittedBy,
				IsResolved = false
			};
			try
			{
				var response = await Client.PostAsJsonAsync("Tickets/PostTicket", ticketToPost);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}

		public async Task DeleteTicket(int id)
		{
			await Client.DeleteAsync($"Tickets?id={id}");
		}

		public async Task UpdateTicket(TicketViewModel ticket)
		{
			await Client.PutAsJsonAsync("Tickets", ticket);
		}
	}
}
