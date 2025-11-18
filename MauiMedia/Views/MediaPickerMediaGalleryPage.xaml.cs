using Microsoft.Maui.Storage;
using System.IO;
using Microsoft.Maui.ApplicationModel;

namespace MauiMedia.Views;

public partial class MediaPickerMediaGalleryPage : ContentPage
{
    public MediaPickerMediaGalleryPage()
    {
        InitializeComponent();

    }

    private async void TakePicture(object sender, EventArgs e)
    {
        var status = await Permissions.RequestAsync<Permissions.Camera>();

        if (status != PermissionStatus.Granted)
            return;

        try
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            if (photo == null)
                return;

            using var stream = await photo.OpenReadAsync();
            var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            ms.Position = 0;

            ImageResult.Source = ImageSource.FromStream(() => ms);
        }
        catch (Exception)
        {
            // Capture cancelled or failed - keep existing behavior
        }
    }


}