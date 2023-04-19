using Microsoft.Maui.Storage;
using NativeMedia;
using System.IO;

namespace MauiMedia.Views;

public partial class MediaPickerMediaGalleryPage : ContentPage
{
    public MediaPickerMediaGalleryPage()
    {
        InitializeComponent();

    }

    private async void TakePicture(object sender, EventArgs e)
    {
        //...
        if (!MediaGallery.CheckCapturePhotoSupport())
            return;

        var status = await Permissions.RequestAsync<Permissions.Camera>();

        if (status != PermissionStatus.Granted)
            return;


        var file = await MediaGallery.CapturePhotoAsync();

        if (file.Type == MediaFileType.Image)
        {
            Stream sourceStream = await file.OpenReadAsync();
            
            //using (FileStream localFileStream = File.OpenWrite(localFilePath))
            //{
            //    await sourceStream.CopyToAsync(localFileStream);
            //}
            ImageResult.Source = ImageSource.FromStream(() => sourceStream);

        }
    }



}