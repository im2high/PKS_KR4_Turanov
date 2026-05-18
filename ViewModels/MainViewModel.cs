using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using TouristGuide.Data;
using TouristGuide.Models;

namespace TouristGuide.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase _currentView = null!;
    public ViewModelBase CurrentView
    {
        get => _currentView;
        set => SetField(ref _currentView, value);
    }

    private string _searchText = string.Empty;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetField(ref _searchText, value))
                FilterCities();
        }
    }

    public ObservableCollection<City> Cities { get; } = new();

    public ICommand OpenCityCommand { get; }
    public ICommand OpenAttractionCommand { get; }
    public ICommand BackToListCommand { get; }
    public ICommand BackToCityCommand { get; }

    private City? _selectedCity;
    private List<City> _allCities = new();

    public MainViewModel()
    {
        OpenCityCommand = new RelayCommand<City>(OpenCity);
        OpenAttractionCommand = new RelayCommand<Attraction>(OpenAttraction);
        BackToListCommand = new RelayCommand(_ => CurrentView = this);
        BackToCityCommand = new RelayCommand(_ =>
        {
            if (_selectedCity != null) OpenCity(_selectedCity);
        });

        LoadAllCities();
        CurrentView = this;
    }

    private void LoadAllCities()
    {
        using var db = new AppDbContext();
        _allCities = db.Cities.ToList();
        FilterCities();
    }

    private void FilterCities()
    {
        Cities.Clear();
        var search = SearchText?.Trim() ?? string.Empty;
        var filtered = string.IsNullOrEmpty(search)
            ? _allCities
            : _allCities.Where(c => c.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

        foreach (var c in filtered)
            Cities.Add(c);
    }

    private void OpenCity(City? city)
    {
        if (city == null) return;
        _selectedCity = city;
        using var db = new AppDbContext();
        var full = db.Cities.Include(c => c.Attractions).First(c => c.Id == city.Id);
        CurrentView = new CityDetailViewModel(full, this);
    }

    private void OpenAttraction(Attraction? a)
    {
        if (a == null) return;
        CurrentView = new AttractionDetailViewModel(a, this);
    }
}

public class RelayCommand<T> : ICommand
{
    private readonly Action<T?> _execute;
    public RelayCommand(Action<T?> execute) => _execute = execute;

    public event EventHandler? CanExecuteChanged
    {
        add { }
        remove { }
    }

    public bool CanExecute(object? p) => true;
    public void Execute(object? p) => _execute(p is T t ? t : default);
}

public class RelayCommand : ICommand
{
    private readonly Action<object?> _execute;
    public RelayCommand(Action<object?> execute) => _execute = execute;

    public event EventHandler? CanExecuteChanged
    {
        add { }
        remove { }
    }

    public bool CanExecute(object? p) => true;
    public void Execute(object? p) => _execute(p);
}
