using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiCamera.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private IFileSaver _fileSaver;
    private IPreferences _preferences;
    private readonly string FolderPathKey = SettingsPageViewModel.FolderPathKey;

    public MainPageViewModel(IFileSaver fileSaver, IPreferences preferences)
    {
        _fileSaver = fileSaver;
        _preferences = preferences;

    }




    public async Task<bool> SaveImage(Stream stream)
    {
        using var cancellationTokenSource = new CancellationTokenSource();
        string dataDir = FileSystem.Current.AppDataDirectory;
        var filePath = Path.Combine(FileSystem.AppDataDirectory, "Attachment1.jpg");
        var fileSaverResult = await _fileSaver.SaveAsync(filePath, stream, cancellationTokenSource.Token);
        if (fileSaverResult.IsSuccessful)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
