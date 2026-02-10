using MauiCollections.Services;
using MauiCollections.ViewModels;

namespace MauiCollections.Views;

public partial class CarouselViewPage : ContentPage
{
	public CarouselViewPage(CarouselPageViewModel viewModel)
	{
        BindingContext = viewModel;
		InitializeComponent();
	}
}