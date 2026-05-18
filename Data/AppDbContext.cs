using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using TouristGuide.Models;

namespace TouristGuide.Data;

public class AppDbContext : DbContext
{
    public DbSet<City> Cities => Set<City>();
    public DbSet<Attraction> Attractions => Set<Attraction>();

    private static string DbPath { get; } = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory, "touristguide.db");

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
