using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiCollections.Models;

namespace MauiCollections.Services;

public interface IHomeDataProvider
{
    List<Home> GetCarouselHomes();
}

public class HomeDataProvider:IHomeDataProvider
{
    List<Home> _homes = new List<Home>();
    private string[] _locations = { "Plam Springs", "San Diego", "Rancho Cucamonga", "Del Cielo", "La Jolla", "Del Mar" };
    private string[] _descriptions = { "Mid Century 5000 sqft - 5 bedrooms", "Modern paradise 3600 sqft 4 bedrooms", "Hidden Oasis 3900 sqft", "Top of the world 4500 sqft", "Near the ocean 2900 sqft", "Vistas of dreams 6000 sqft" };

    public HomeDataProvider()
    {
        for (int i = 0; i < 6; i++)
        {
            var home= new Home();
            home.CarouselPhoto  = $"home{i+1:D2}.jpg";
            home.Location  = $"{_locations[i]}";
            home.Description  = $"{_descriptions[i]}";
            _homes.Add(home);
        }
    }

    public List<Home> GetCarouselHomes()
    {
        return _homes;
    }
}