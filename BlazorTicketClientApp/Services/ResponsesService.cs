using BlazorTicketClientApp.Models;
using Newtonsoft.Json;
using Shared.Models;
using System.Net.Http.Json;

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
