﻿namespace PerondaApp.Data;

using Microsoft.EntityFrameworkCore;
using PerondaApp.Data.Entities;

public class PerondaAppDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<BusinessPartner> BusinessPartners => Set<BusinessPartner>();

    //public DbSet<Tile> Tiles => Set<Tile>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
}
