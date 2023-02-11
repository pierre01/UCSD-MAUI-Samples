using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiCollections.Models;

namespace MauiCollections.ViewModels;

public partial  class CarouselPageViewModel:ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Home> _homes;
}