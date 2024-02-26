using BlazorTicketClientApp.Models;

namespace BlazorTicketClientApp.Services
{
	public interface ITicketsService
	{
		Task<List<TicketViewModel>> GetAllAsync();

		Task PostTicketAsync(TicketViewModel ticket);

		Task<TicketViewModel> GetTicketByIdAsync(int id);

		Task DeleteTicket(int id);

		Task UpdateTicket(TicketViewModel ticket);
	}
}
