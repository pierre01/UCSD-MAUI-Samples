using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiCamera.ViewModels
{
    public partial class SettingsPageViewModel:ObservableObject
    {
        IFolderPicker _folderPicker;
        IPreferences _preferences;
        public static readonly string FolderNameKey = "FolderName";
        public static readonly string FolderPathKey = "FolderPath";

        public SettingsPageViewModel(IFolderPicker folderPicker, IPreferences preferences)
        {
            _folderPicker = folderPicker;
            _preferences = preferences;

            // Get folder Information from the Preferences
            FolderName = _preferences.Get<string>(FolderNameKey, null);
            FolderPath = _preferences.Get<string>(FolderPathKey, null);
        }

        [ObservableProperty]
        string _folderName;        
        
        [ObservableProperty]
        string _folderPath;

        [RelayCommand]
        public async void PickFolder()
        {
            try
            {
                CancellationToken cancellationToken = default;
                PermissionStatus status = await Permissions.RequestAsync<Permissions.StorageRead >();
                status = await Permissions.RequestAsync<Permissions.StorageWrite>();
                status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
                status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
                var result = await _folderPicker.PickAsync(cancellationToken);
                result.EnsureSuccess();
                FolderName = result.Folder.Name;
                FolderPath = result.Folder.Path;
                // Save Settings
                _preferences.Set<string>(FolderNameKey, FolderName);
                _preferences.Set<string>(FolderPathKey, FolderPath);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
