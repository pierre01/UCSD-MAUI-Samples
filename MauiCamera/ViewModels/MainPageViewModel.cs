using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MauiCamera.ViewModels;

public partial class MainPageViewModel:ObservableObject
{
    private IFileSaver _fileSaver;
    private IPreferences _preferences;
    private readonly string FolderPathKey = SettingsPageViewModel.FolderPathKey;

    public MainPageViewModel(IFileSaver fileSaver,IPreferences preferences)
    {
        _fileSaver = fileSaver;
        _preferences = preferences;
       
    }




    public async Task<bool> SaveImage(Stream stream)
    {
        using var cancellationTokenSource = new CancellationTokenSource();

        var fileSaverResult = await _fileSaver.SaveAsync("MyImage.Jpg", stream, cancellationTokenSource.Token);
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
