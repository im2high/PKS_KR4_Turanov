using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TouristGuide.Models;

public class City
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public int Population { get; set; }
    public string History { get; set; } = string.Empty;
    public string CoatOfArms { get; set; } = string.Empty;   // путь или URL
    public string Photo { get; set; } = string.Empty;         // путь или URL
    public List<Attraction> Attractions { get; set; } = new();
}