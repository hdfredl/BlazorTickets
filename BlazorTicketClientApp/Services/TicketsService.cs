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
					return tickets;
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


				string jsonString = JsonConvert.SerializeObject(ticketToPost);

				var response = await Client.PostAsJsonAsync("Tickets/PostTicket", jsonString);

				if (response.IsSuccessStatusCode)
				{
					// Det funkade
				}

				else
				{
					//Funkade inte
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}
	}
}
