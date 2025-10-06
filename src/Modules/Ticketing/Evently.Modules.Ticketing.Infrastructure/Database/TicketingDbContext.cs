using Evently.Common.Application.Abstraction.Data;

namespace Evently.Modules.Ticketing.Infrastructure.Database;

public sealed class TicketingDbContext(DbContextOptions<TicketingDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Id).ValueGeneratedNever();
            entity.Property(t => t.Code).HasMaxLength(50);
            entity.HasIndex(t => t.Code).IsUnique();
            entity.HasIndex(t => t.CustomerId);
            entity.HasIndex(t => t.EventId);
            entity.HasIndex(t => t.OrderId);
            entity.HasIndex(t => t.TicketTypeId);
        });
    }
}