using Newtonsoft.Json;
using Shared.Models;

namespace BlazorTicketClientApp.Models
{
	public class TicketViewModel
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		[JsonProperty("submittedBy")]
		public string? SubtmittedBy { get; set; }
		public bool? IsResolved { get; set; }
		//Gjorde tag bara som en string i min TicketViewModel
		public string? Tag { get; set; }

		// För att hämta resonses
		public List<TicketModel>? Responses { get; set; }

	}
}
