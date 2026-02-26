using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Storage;
using MauiCamera.ViewModels;

namespace MauiCamera.Views;

public partial class MainPage : ContentPage
{

    readonly IFileSaver fileSaver;
    readonly string imagePath;

    Stream videoRecordingStream = Stream.Null;

    public MainPage(MainPageViewModel viewModel, IFileSystem fileSystem, IFileSaver fileSaver)
    {
        BindingContext = viewModel;
        InitializeComponent();

        this.fileSaver = fileSaver;
        imagePath = Path.Combine(fileSystem.CacheDirectory, "camera-view-image.jpg");

        CamView.MediaCaptured += OnMediaCaptured;
    }

    void StartCameraPreview(object? sender, EventArgs? e)
    {
        var token = (BindingContext as MainPageViewModel)?.Token ?? CancellationToken.None;

        if (CamView.StartCameraPreviewCommand?.CanExecute(token) == true)
        {
            CamView.StartCameraPreviewCommand.Execute(token);
        }
    }

    void StopCameraPreview(object? sender, EventArgs? e)
    {
        if (CamView.StopCameraPreviewCommand?.CanExecute(null) == true)
        {
            CamView.StopCameraPreviewCommand.Execute(null);
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

#if ANDROID || IOS
        var cameraPermissionsRequest = await Permissions.RequestAsync<Permissions.Camera>();
        var microphonePermissionsRequest = await Permissions.RequestAsync<Permissions.Microphone>();

        if (cameraPermissionsRequest is not PermissionStatus.Granted)
        {
            await Shell.Current.CurrentPage.DisplayAlertAsync("Camera permission is not granted.", "Please grant the permission to use this feature.", "OK");
            return;
        }

        if (microphonePermissionsRequest is not PermissionStatus.Granted)
        {
            await Shell.Current.CurrentPage.DisplayAlertAsync("Microphone permission is not granted.", "Please grant the permission to use this feature.", "OK");
            return;
        }
#endif
    }

    void CaptureImage(object? sender, EventArgs? e)
    {
        var token = (BindingContext as MainPageViewModel)?.Token ?? CancellationToken.None;

        if (CamView.CaptureImageCommand?.CanExecute(token) == true)
        {
            CamView.CaptureImageCommand.Execute(token);
        }
    }


    async void OnImageTapped(object? sender, TappedEventArgs args)
    {
        if (image.Source is null || image.Source.IsEmpty)
        {
            return;
        }

    }

    void Cleanup()
    {
        CamView.MediaCaptured -= OnMediaCaptured;
    }

    void OnMediaCaptured(object? sender, MediaCapturedEventArgs e)
    {
        using var localFileStream = File.Create(imagePath);

        e.Media.CopyTo(localFileStream);

        Dispatcher.Dispatch(() =>
        {
            // workaround for https://github.com/dotnet/maui/issues/13858
#if ANDROID
            image.Source = ImageSource.FromStream(() => File.OpenRead(imagePath));
#else
			image.Source = ImageSource.FromFile(imagePath);
#endif

            debugText.Text = $"Image saved to {imagePath}";
        });
    }

    void ZoomIn(object? sender, EventArgs? e)
    {
        CamView.ZoomFactor += 1.0f;
    }

    void ZoomOut(object? sender, EventArgs? e)
    {
        CamView.ZoomFactor -= 1.0f;
    }

    async void SetNightMode(object? sender, EventArgs? e)
    {
#if ANDROID
        await CamView.SetExtensionMode(AndroidX.Camera.Extensions.ExtensionMode.Night);
#else
		await Task.CompletedTask;
#endif
    }

    async void StartCameraRecording(object? sender, EventArgs? e)
    {
        await CamView.StartVideoRecording(CancellationToken.None);
    }

    async void StopCameraRecording(object? sender, EventArgs? e)
    {
        videoRecordingStream = await CamView.StopVideoRecording(CancellationToken.None);
    }

    async void SaveVideo(object? sender, EventArgs? e)
    {
        if (videoRecordingStream == Stream.Null)
        {
            await DisplayAlertAsync("Unable to Save Video", "Stream is null", "OK");
        }
        else
        {
            var status = await Permissions.RequestAsync<Permissions.StorageWrite>();
            if (status is not PermissionStatus.Granted)
            {
                await Shell.Current.CurrentPage.DisplayAlertAsync("Storage permission is not granted.", "Please grant the permission to use this feature.", "OK");
                return;
            }

            await fileSaver.SaveAsync("recording.mp4", videoRecordingStream);
            await videoRecordingStream.DisposeAsync();
            videoRecordingStream = Stream.Null;
        }
    }
}