using System.Collections.ObjectModel;
using TouristGuide.Models;

namespace TouristGuide.ViewModels;

public class CityDetailViewModel : ViewModelBase
{
    public City City { get; }
    public ObservableCollection<Attraction> Attractions { get; } = new();
    public MainViewModel Main { get; }

    public CityDetailViewModel(City city, MainViewModel main)
    {
        City = city;
        Main = main;
        foreach (var a in city.Attractions)
            Attractions.Add(a);
    }
}