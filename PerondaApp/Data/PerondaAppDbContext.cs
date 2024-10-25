namespace PerondaApp.Data;

using Microsoft.EntityFrameworkCore;
using PerondaApp.Entities;

public class PerondaAppDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<BusinessPartner> BusinessPartners => Set<BusinessPartner>();

    public DbSet<Tile> Tiles => Set<Tile>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);  //określamy jak będzie się nazywać nasza baza danych w pamięci
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        //var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        //IConfiguration configuration = configurationBuilder.Build();
        //optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));   skąd ja to wzięłam?
    }
}
