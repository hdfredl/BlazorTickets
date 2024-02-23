namespace BlazorTicketClientApp.Models
{
	public class TicketViewModel
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? SubtmittedBy { get; set; }
		public bool? IsResolved { get; set; }
		//Gjorde tag bara som en string i min TicketViewModel
		public string? Tag { get; set; }
	}
}
