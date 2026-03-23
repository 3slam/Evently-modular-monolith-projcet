using Evently.Common.Application.Abstraction.Data;
using Evently.Modules.Users.Domain.Models;
using Microsoft.EntityFrameworkCore;
 

namespace Evently.Modules.Users.Infrastructure.Data;

public sealed class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options) , IUnitOfWork
{
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        base.OnModelCreating(modelBuilder);
    }
}

