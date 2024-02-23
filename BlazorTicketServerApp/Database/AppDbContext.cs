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

    public DbSet<TagModel> Tags { get; set; }

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



        SeedData(modelBuilder);
    }



    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TagModel>().HasData(
            new TagModel { Id = 1, Name = "CSharp" }
        );

        modelBuilder.Entity<TicketModel>().HasData(
            new TicketModel
            {
                Id = 1,
                Title = "ticket 1",
                Description = "heheh",
                SubmittedBy = "fredrik",
                IsResolved = false,
            }
        );

        modelBuilder.Entity<ResponseModel>().HasData(
            new ResponseModel
            {
                Id = 1,
                Response = "noob",
                SubmittedBy = "fredde-dev",
                TicketId = 1, // tilhhör med Ticket 1, ticketId
            }
        );

        modelBuilder.Entity<TicketTag>().HasData(
            new TicketTag { TicketId = 1, TagId = 1 } // knyter ihop TicketId(TicketModel) med TagId(TagModel)
        );


    }

}
