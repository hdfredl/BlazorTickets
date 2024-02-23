using BlazorTicketClientApp.Models;

namespace BlazorTicketClientApp.Services
{
	public interface ITicketsService
	{
		Task<List<TicketViewModel>> GetAllAsync();

		Task PostTicketAsync(TicketViewModel ticket);
	}
}
