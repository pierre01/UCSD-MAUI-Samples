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
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                // save the file into local storage
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                //string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

                using (Stream sourceStream = await photo.OpenReadAsync())
                {
                    //using (FileStream localFileStream = File.OpenWrite(localFilePath))
                    //{
                    //    await sourceStream.CopyToAsync(localFileStream);
                    //}
                    ImageResult.Source = ImageSource.FromStream(() => sourceStream);

                }


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
