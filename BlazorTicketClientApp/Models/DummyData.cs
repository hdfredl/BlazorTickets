namespace BlazorTicketClientApp.Models
{
	public static class DummyData
	{
		public static List<TicketViewModel> Tickets { get; set; } = new()
		{
			new TicketViewModel()
			{
				Id = 1,
				Title = "Title 1",
				Description = "First ticket description",
				SubtmittedBy = "Otto",
				IsResolved = false,
				Tag = "C#"
			},
			new TicketViewModel()
			{
				Id = 2,
				Title = "Title 2",
				Description = "Second ticket description",
				SubtmittedBy = "Calle",
				IsResolved = false,
				Tag = "Json"
			},
			new TicketViewModel()
			{
				Id = 3,
				Title = "Title 3",
				Description = "Third ticket description",
				SubtmittedBy = "Fredrik",
				IsResolved = false,
				Tag = "JavaScript"
			}
		};

		public static List<ResponseViewModel> Responses { get; set; } = new()
		{
			new ResponseViewModel()
			{
				Id = 1,
				Response = "First response",
				SubmittedBy = "Otto",
			},
			new ResponseViewModel()
			{
				Id = 2,
				Response = "Second response",
				SubmittedBy = "Calle",
			},
			new ResponseViewModel()
			{
				Id = 3,
				Response = "Third response",
				SubmittedBy = "Fredrik",
			},
		};
	}
}
