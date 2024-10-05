using CommunityToolkit.Maui.Core;
using MauiCamera.ViewModels;

namespace MauiCamera.Views;

/// <summary>
/// A page that displays the camera feed and allows the user to take a picture.
/// From the community toolkit.
/// </summary>
public partial class CommunityCamera : ContentPage
{
	public CommunityCamera()
	{
		InitializeComponent();
	    BindingContext  = new CommunityCameraViewModel((ICameraProvider) ActiveCamera);
	}
}