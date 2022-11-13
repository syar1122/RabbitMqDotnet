using Microsoft.EntityFrameworkCore;
using ProducerRabbitMq.Entities;

namespace ProducerRabbitMq.Repositories;

public class UserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<User?> CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> ListUsers() => await _context.Users.AsNoTracking().ToListAsync();

}