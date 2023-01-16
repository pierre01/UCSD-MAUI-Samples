using System.IO;

namespace MauiMedia.Views;

public partial class MediaPickerTestsPage : ContentPage
{
	public MediaPickerTestsPage()
	{
		InitializeComponent();
	}


    private async void OnTakePicture(object sender, EventArgs e)
    {

        if (MediaPicker.Default.IsCaptureSupported)
        {
            PermissionStatus status = await Permissions.RequestAsync<Permissions.Media>();
            status = await Permissions.RequestAsync<Permissions.Camera>();
            status = await Permissions.RequestAsync<Permissions.Photos>();
            status = await Permissions.RequestAsync<Permissions.StorageRead>();
            status = await Permissions.RequestAsync<Permissions.StorageWrite>();

            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                ImageResult.Source = null;
                // save the file into local storage
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                //string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

                Stream sourceStream = await photo.OpenReadAsync();
                

                ImageResult.Source = ImageSource.FromStream(() => sourceStream);
                sourceStream.Seek(0, SeekOrigin.Begin);
                //sourceStream.DisposeAsync();


            }
        }
          
    }
    public async Task<ImageSource> TakeScreenshotAsync()
    {
        if (Screenshot.Default.IsCaptureSupported)
        {
            IScreenshotResult screen = await Screenshot.Default.CaptureAsync();

            Stream stream = await screen.OpenReadAsync();

            return ImageSource.FromStream(() => stream);
        }

        return null;
    }
}
