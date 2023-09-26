namespace MauiStorage.Views;

public partial class FilePickerPage : ContentPage
{
	public FilePickerPage()
	{
		InitializeComponent();
	}

    public async Task<FileResult> PickAndShow(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                    ImageToDisplay.Source = ImageSource.FromFile(result.FullPath);
            }

            return result;
        }
        catch (TaskCanceledException)
        {
            // The user canceled or something went wrong
            // TODO: handle
        }

        return null;
    }


    private async void PickFile_Clicked(object sender, EventArgs e)
    {
        //var customFileType = new FilePickerFileType(
        //        new Dictionary<DevicePlatform, IEnumerable<string>>
        //        {
        //            { DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // UTType values
        //            { DevicePlatform.Android, new[] { "application/comics" } }, // MIME type
        //            { DevicePlatform.WinUI, new[] { ".cbr", ".cbz" } }, // file extension
        //            { DevicePlatform.Tizen, new[] { "*/*" } },
        //            { DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // UTType values
        //        });

       var customFileType = FilePickerFileType.Images;

        PickOptions options = new()
        {
            PickerTitle = "Please select an image",
            FileTypes = customFileType,
        };

        await PickAndShow(options);
    }
}