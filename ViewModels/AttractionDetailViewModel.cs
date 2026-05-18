using TouristGuide.Models;

namespace TouristGuide.ViewModels;

public class AttractionDetailViewModel : ViewModelBase
{
    public Attraction Attraction { get; }
    public MainViewModel Main { get; }

    public AttractionDetailViewModel(Attraction attraction, MainViewModel main)
    {
        Attraction = attraction;
        Main = main;
    }
}