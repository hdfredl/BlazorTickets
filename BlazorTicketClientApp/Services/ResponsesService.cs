using System.Net.Http.Json;
using BlazorTicketClientApp.Models;
using Newtonsoft.Json;
using Shared.Models;

namespace BlazorTicketClientApp.Services
{
	public class ResponsesService : IResponsesService
	{
		public HttpClient Client { get; set; } = new()
		{
			BaseAddress = new Uri("https://localhost:7034/api/")
		};
		public Task<List<ResponseViewModel>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<List<ResponseViewModel>> GetResponesToTicketAsync(int id)
		{
			var response = await Client.GetAsync($"Responses/{id}");
			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();

				List<ResponseViewModel> responses = JsonConvert.DeserializeObject<List<ResponseViewModel>>(jsonResponse);

				if (responses != null)
				{
					// se om det finns responses,Gå igenom alla tickets, hämta o ändra till true om finns eller falase om ej
					foreach (var ticket in responses)
					{
						if (ticket.Response != null && ticket.Response.Any())
						{
							ticket.IsResolved = true;

						}
						else
						{
							ticket.IsResolved = false;
						}
						Console.WriteLine($"Ticket Id: {ticket.Id}, Initial IsResolved: {ticket.IsResolved}, Responses Count: {ticket.Response}");
					}
					return responses;
				}

				throw new JsonException();
			}
			throw new HttpRequestException();
		}

		public Task<ResponseViewModel> GetResponse(int id)
		{
			throw new NotImplementedException();
		}

		public async Task PostResponseAsync(ResponseModel response)
		{
			await Client.PostAsJsonAsync("Responses", response);
		}
	}
}
