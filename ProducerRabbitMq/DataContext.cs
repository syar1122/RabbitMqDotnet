using Microsoft.EntityFrameworkCore;
using ProducerRabbitMq.Entities;

namespace ProducerRabbitMq;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql("Host=localhost; Database=test; Username=postgres; Password=password123");
    }

    public DbSet<User> Users { get; set; } = null!;
}