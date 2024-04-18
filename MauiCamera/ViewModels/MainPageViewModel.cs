using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiCamera.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private IFileSaver _fileSaver;
    private IPreferences _preferences;
    private IFileSystem _fileSystem;
    private readonly string FolderPathKey = SettingsPageViewModel.FolderPathKey;

    public MainPageViewModel(IFileSaver fileSaver, IPreferences preferences, IFileSystem fileSystem)
    {
        _fileSaver = fileSaver;
        _preferences = preferences;
        _fileSystem = fileSystem;

    }




    public async Task<bool> SaveImage(Stream stream)
    {
        using var cancellationTokenSource = new CancellationTokenSource();
        string dataDir = _fileSystem.AppDataDirectory;
        var filePath = Path.Combine(dataDir, "Attachment1.jpg");
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
