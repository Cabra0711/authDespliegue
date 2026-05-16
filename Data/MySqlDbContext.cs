using Microsoft.EntityFrameworkCore;
using PracticaAuth.Models;

namespace PracticaAuth.Data;

public class MySqlDbContext : DbContext
{
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
}