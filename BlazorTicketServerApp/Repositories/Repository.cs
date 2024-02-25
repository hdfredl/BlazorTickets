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
			// GÖR SÅ ATT BOOL KAN ÄNDRAS ISRESOLVED TRUE ELLE FALASE
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



	// Ta bort en response
	public async Task RemoveResponseAsync(int id)
	{
		// Hämta en response med Id
		ResponseModel? deleteResponse = await _context.Responses.FirstOrDefaultAsync(r => r.Id == id);

		if (deleteResponse != null)
		{
			_context.Responses.Remove(deleteResponse);
			await _context.SaveChangesAsync();
		}
	}

	// Uppdatera en respons
	public async Task UpdateResponseAsync(ResponseModel response)
	{
		ResponseModel? updateResponse = await _context.Responses.FirstOrDefaultAsync(r => r.Id == response.Id);

		// Uppdatera bara responses i en ticket.
		if (updateResponse != null)
		{
			updateResponse.Response = response.Response;

			await _context.SaveChangesAsync();
		}
	}

	// -------------------------------------------------------------------------------------------------

	//  Tag name 

	public async Task<List<TagModel>> GetAllTagsAsync()
	{
		return await _context.Tags.ToListAsync();
	}

	// Hämta Tag Id
	public async Task<TagModel?> GetTagByIdAsync(int tagId)
	{
		return await _context.Tags.FirstOrDefaultAsync(t => t.Id == tagId);
	}

	// Adda en tag
	public async Task AddTagAsync(TagModel tag)
	{
		_context.Tags.Add(tag);
		await _context.SaveChangesAsync();
	}

	// tabort en tag
	public async Task RemoveTagAsync(int id)
	{
		// Get a tag by Id
		TagModel deleteTag = await GetTagByIdAsync(id);

		if (deleteTag != null)
		{
			_context.Tags.Remove(deleteTag);
			await _context.SaveChangesAsync();
		}
	}

	// Update tag
	public async Task UpdateTagAsync(TagModel tag)
	{
		TagModel? updateTag = await GetTagByIdAsync(tag.Id);

		// Update tag name
		if (updateTag != null)
		{
			updateTag.Name = tag.Name;
			await _context.SaveChangesAsync();
		}
	}
}
