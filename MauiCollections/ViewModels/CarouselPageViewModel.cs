using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiCollections.Models;
using MauiCollections.Services;

namespace MauiCollections.ViewModels;

public partial class CarouselPageViewModel : ObservableObject
{
    [ObservableProperty] 
    private ObservableCollection<Home> _homes;

    public CarouselPageViewModel(IHomeDataProvider homeProvider)
    {
        Homes = new ObservableCollection<Home>(homeProvider.GetCarouselHomes());
    }
}