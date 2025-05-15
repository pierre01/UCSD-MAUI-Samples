using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiCamera.ViewModels;

public partial class CommunityCameraViewModel(ICameraProvider cameraProvider) : ObservableObject
{

    [ObservableProperty]
    public partial CameraFlashMode FlashMode {get; set;}

    [ObservableProperty]
    private CameraView _selectedCamera;

    [ObservableProperty]
    private Size _selectedResolution;

    [ObservableProperty]
    private float _currentZoom;

    [ObservableProperty]
    string _cameraNameText = "", _zoomRangeText = "", _currentZoomText = "", _flashModeText = "", _resolutionText = "";

    public IReadOnlyList<CameraInfo> Cameras => cameraProvider?.AvailableCameras ?? [];

    public CancellationToken Token => CancellationToken.None;

    public ICollection<CameraFlashMode> FlashModes { get; } = Enum.GetValues<CameraFlashMode>();

    [RelayCommand]
    async Task RefreshCameras(CancellationToken token) => await cameraProvider.RefreshAvailableCameras(token);

    [RelayCommand]
    private void CaptureImage()
    {
        // Capture the image
       // SelectedCamera?.
    }
    [RelayCommand]
    private void StartCameraPreview()
    {
        if (SelectedCamera is null)
        {
            return;
        }
        // Start the camera preview
        
    }
    [RelayCommand]
    private void StopCameraPreview()
    {
        //SelectedCamera.
    }


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

    void UpdateFlashModeText()
    {
        if (SelectedCamera is null)
        {
            return;
        }
        //FlashModeText = $"{(SelectedCamera.CameraFlashMode ? $"Flash mode: {FlashMode}" : "Flash not supported")}";
    }

    void UpdateCurrentZoomText()
    {
        CurrentZoomText = $"Current Zoom: {CurrentZoom}";
    }

    void UpdateResolutionText()
    {
        ResolutionText = $"Selected Resolution: {SelectedResolution.Width} x {SelectedResolution.Height}";
    }
}


