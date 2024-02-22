using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorTicketServerApp.Database;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}

	public DbSet<TicketModel> Tickets { get; set; }

	public DbSet<ResponseModel> Responses { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<TicketTag>()
		.HasKey(tt => new { tt.TicketId, tt.TagId }); // Sätter en sammansatt p
													  // Konfigurera många-till-många relationen mellan TicketModel och TagMo
		modelBuilder.Entity<TicketTag>()
		.HasOne(tt => tt.Ticket)
		.WithMany(t => t.TicketTags)
		.HasForeignKey(tt => tt.TicketId);
		modelBuilder.Entity<TicketTag>()
		.HasOne(tt => tt.Tag)
		.WithMany(t => t.TicketTags)
		.HasForeignKey(tt => tt.TagId);
		// Konfigurera en-till-många-relationen mellan TicketModel och ResponseMode
		modelBuilder.Entity<ResponseModel>()
		.HasOne(r => r.Ticket)
		.WithMany(t => t.Responses)
		.HasForeignKey(r => r.TicketId);
	}

}
