using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;


public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    private string DbPath { get; set; }

    
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Kowalski",
                    BirthDate = new DateOnly(2000, 10, 10),
                    Email = "adam@gmail.com",
                    PhoneNumber = "123456789",
                    Created = DateTime.Now
                },
                new ContactEntity()
                {
                    Id = 2,
                    FirstName = "Kamil",
                    LastName = "Rulaniec",
                    BirthDate = new DateOnly(2003, 12, 23),
                    Email = "kamil@gmail.com",
                    PhoneNumber = "243546321",
                    Created = DateTime.Now
                }
                );
    }
}