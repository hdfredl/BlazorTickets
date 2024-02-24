using BlazorTicketClientApp.Models;
using Shared.Models;

namespace BlazorTicketClientApp.Services
{
	public interface IResponsesService
	{
		Task<List<ResponseViewModel>> GetAllAsync();
		Task<List<ResponseViewModel>> GetResponesToTicketAsync(int id);
		Task<ResponseViewModel> GetResponse(int id);
		Task PostResponseAsync(ResponseModel response);
	}
}
