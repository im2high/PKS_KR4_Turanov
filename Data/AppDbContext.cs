using Microsoft.EntityFrameworkCore;
using TouristGuide.Models;

namespace TouristGuide.Data;

public class AppDbContext : DbContext
{
    public DbSet<City> Cities => Set<City>();
    public DbSet<Attraction> Attractions => Set<Attraction>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=touristguide.db");
}