using System.ComponentModel.DataAnnotations;

namespace TouristGuide.Models;

public class Attraction
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string History { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
    public string WorkingHours { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;         // "" если бесплатно
    public int CityId { get; set; }
    public City? City { get; set; }
}