using ContactList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ContactList.Infrastructure;
public class ContactListDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactCategory> ContactCategories { get; set; }
    public DbSet<ContactSubCategory> ContactSubCategories { get; set; }

    public ContactListDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactListDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ContactListDatabase"), b => b.MigrationsAssembly("ContactList.Infrastructure"));
    }
}
