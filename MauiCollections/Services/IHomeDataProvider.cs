using MauiCollections.Models;

namespace MauiCollections.Services;

public interface IHomeDataProvider
{
    List<Home> GetCarouselHomes();
}
