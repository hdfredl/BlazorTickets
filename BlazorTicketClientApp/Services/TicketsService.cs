using BlazorTicketClientApp.Models;
using Newtonsoft.Json;

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

        public Task PostTicketAsync(TicketViewModel ticket)
        {
            throw new NotImplementedException();
        }
    }
}
