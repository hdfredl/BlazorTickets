namespace Shared.Models;

public class ResponseModel
{
	public int Id { get; set; }
	public string Response { get; set; } = null!;
	public string SubmittedBy { get; set; } = null!;
	public int TicketId { get; set; }
	public TicketModel? Ticket { get; set; }


}
