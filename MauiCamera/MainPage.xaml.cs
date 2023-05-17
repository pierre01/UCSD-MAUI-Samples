using Camera.MAUI;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Storage;
using MauiCamera.ViewModels;
using System.Text;
using System.Threading;

namespace MauiCamera
{
    public partial class MainPage : ContentPage
    {
        // https://github.com/hjam40/Camera.MAUI

        private MainPageViewModel _viewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
        }





        public async Task Takepic()
        {
            
            var stream = await CameraView.TakePhotoAsync();
            
            if (stream != null)
            {
                if (await _viewModel.SaveImage(stream))
                {

                }
                //var result = ImageSource.FromStream(() => stream);
                //SnapPreview.Source = result;
            }
        }


        private int _currentCamera = 0;

        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraView_CamerasLoaded(object sender, EventArgs e)
        {
            if (CameraView.NumCamerasDetected > 0)
            {
                if (CameraView.NumMicrophonesDetected > 0)
                    CameraView.Microphone = CameraView.Microphones.First();
                CameraView.Camera = CameraView.Cameras.First();
                var resList = CameraView.Camera.AvailableResolutions;
                // Get the largest resolution
                var maxRes = GetLargestSize(resList);
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    if (await CameraView.StartCameraAsync(maxRes) == CameraResult.Success)
                    {
                        //ControlButton.Text = "Stop";
                        //playing = true;
                    }
                });
            }
        }

        /// <summary>
        ///  Get the largest camera resolution
        /// </summary>
        /// <param name="sizes">All the camera supported resolutions</param>
        /// <returns></returns>
        private Size GetLargestSize(List<Size> sizes)
        {

            return sizes.OrderByDescending(s => s.Width * s.Height).FirstOrDefault();
        }

        private void CameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
        {

        }

        private async void CameraSnaped(object sender, EventArgs e)
        {
            await Takepic();
        }

        private async void CameraChanged(object sender, EventArgs e)
        {
            _currentCamera++;
            if (CameraView.NumCamerasDetected > 0)
            {
                if (CameraView.NumMicrophonesDetected > 0)
                    CameraView.Microphone = CameraView.Microphones.First();
                if(CameraView.Cameras.Count <= _currentCamera)
                {
                    _currentCamera = 0;
                }
                await CameraView.StopCameraAsync();
                //MainThread.BeginInvokeOnMainThread(async () =>
                //{
                //    if ( await CameraView.StopCameraAsync() == CameraResult.Success)
                //    {
                //        //ControlButton.Text = "Stop";
                //        //playing = true;
                //    }
                //});
                
                CameraView.Camera = CameraView.Cameras[_currentCamera];
                CameraIndexButton.Text = $"Camera[{_currentCamera}]";
                var resList = CameraView.Camera.AvailableResolutions;
                // Get the largest resolution
                var maxRes = GetLargestSize(resList);
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    if (await CameraView.StartCameraAsync(maxRes) == CameraResult.Success)
                    {
                        //ControlButton.Text = "Stop";
                        //playing = true;
                    }
                });
            }
        }
    }
}