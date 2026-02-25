using CommunityToolkit.Maui.Core;
  
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiCamera.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    readonly ICameraProvider cameraProvider;
    public MainPageViewModel(ICameraProvider cameraProvider)
    {
        this.cameraProvider = cameraProvider;

        cameraProvider.AvailableCamerasChanged += HandleAvailableCamerasChanged;
    }

    public IReadOnlyList<CameraInfo> Cameras => cameraProvider.AvailableCameras ?? [];

    public CancellationToken Token => CancellationToken.None;

    public ICollection<CameraFlashMode> FlashModes { get; } = Enum.GetValues<CameraFlashMode>();

    [ObservableProperty]
    public partial CameraFlashMode FlashMode { get; set; }

    [ObservableProperty]
    public partial CameraInfo? SelectedCamera { get; set; }

    [ObservableProperty]
    public partial Size SelectedResolution { get; set; }

    [ObservableProperty]
    public partial float CurrentZoom { get; set; }

    [ObservableProperty]
    public partial string CameraNameText { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ZoomRangeText { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string CurrentZoomText { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string FlashModeText { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ResolutionText { get; set; } = string.Empty;

    partial void OnFlashModeChanged(CameraFlashMode value)
    {
        UpdateFlashModeText();
    }

    partial void OnCurrentZoomChanged(float value)
    {
        UpdateCurrentZoomText();
    }

    partial void OnSelectedResolutionChanged(Size value)
    {
        UpdateResolutionText();
    }

    partial void OnSelectedCameraChanged(CameraInfo? oldValue, CameraInfo? newValue)
    {
        UpdateCameraInfoText();
    }

    void UpdateCameraInfoText()
    {
        if (SelectedCamera is null)
        {
            CameraNameText = string.Empty;
            ZoomRangeText = string.Empty;
        }
        else
        {
            CameraNameText = $"{SelectedCamera.Name}";
            ZoomRangeText = $"Min Zoom: {SelectedCamera.MinimumZoomFactor}, Max Zoom: {SelectedCamera.MaximumZoomFactor}";
            UpdateFlashModeText();
        }
    }

    void UpdateFlashModeText()
    {
        if (SelectedCamera is null)
        {
            FlashModeText = string.Empty;
        }
        else
        {
            FlashModeText = $"{(SelectedCamera.IsFlashSupported ? $"Flash mode: {FlashMode}" : "Flash not supported")}";
        }
    }

    void UpdateCurrentZoomText()
    {
        CurrentZoomText = $"Current Zoom: {CurrentZoom}";
    }

    void UpdateResolutionText()
    {
        ResolutionText = $"Selected Resolution: {SelectedResolution.Width} x {SelectedResolution.Height}";
    }

    void HandleAvailableCamerasChanged(object? sender, IReadOnlyList<CameraInfo>? e)
    {
        OnPropertyChanged(nameof(Cameras));
    }
}


