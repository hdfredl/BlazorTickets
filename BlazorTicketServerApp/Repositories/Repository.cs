using BlazorTicketServerApp.Database;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorTicketServerApp.Repositories;

public class Repository
{
	private readonly AppDbContext _context;


	public Repository(AppDbContext context)
	{
		_context = context;
	}

	// TICKETS
	// Hämta Id 
	public async Task<TicketModel?> GetTicketByIdAsync(int ticketId)
	{
		return await _context.Tickets.FirstOrDefaultAsync(p => p.Id == ticketId);
	}
	// Hämta alla tickets 
	public async Task<List<TicketModel>> GetAllTicketsAsync()
	{
		return await _context.Tickets.ToListAsync();
	}

	// Adda en ticket
	public async Task AddTicketAsync(TicketModel ticket)
	{
		_context.Tickets.Add(ticket);
		await _context.SaveChangesAsync();
	}

	//Delete:a en ticket
	public async Task RemoveTicketAsync(int id)
	{
		// Hämta en ticket med Id
		TicketModel deleteTicket = await GetTicketByIdAsync(id);

		if (deleteTicket != null)
		{
			_context.Tickets.Remove(deleteTicket);
			await _context.SaveChangesAsync();
		}
	}

	// Uppdatera en ticket model och tag objekt
	public async Task UpdateTicket(TicketModel ticket)
	{
		TicketModel? updateTicket = await GetTicketByIdAsync(ticket.Id);

		// Uppdatera Tickets descrip
		if (updateTicket != null)
		{
			updateTicket.Description = ticket.Description;

		}
		await _context.SaveChangesAsync();
	}


	// ------------------------------------------------------------------------------------------------

	// Responses
	// Hämta alla responses
	public async Task<List<ResponseModel>> GetAllResponsesAsync()
	{
		return await _context.Responses.ToListAsync();
	}

	// Hämta specifik id - resp
	public async Task<List<ResponseModel>> GetResponsesForTicketAsync(int ticketId)
	{
		return await _context.Responses.Where(r => r.TicketId == ticketId).ToListAsync();
	}


	// Adda en response
	public async Task AddResponseAsync(ResponseModel response)
	{
		_context.Responses.Add(response);
		await _context.SaveChangesAsync();
	}




	// -------------------------------------------------------------------------------------------------

	// Tag ändra Tag name o ta bort?



}
