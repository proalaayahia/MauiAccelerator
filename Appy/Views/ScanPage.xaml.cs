using CommunityToolkit.Mvvm.Messaging;

namespace Appy.Views;

public partial class ScanPage : ContentPage
{
    public ScanPage()
    {
        InitializeComponent();
    }
    private async void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
        else
            await Shell.Current.DisplayAlert("", "Camera can not detected!", "Cancle");
    }

    private async void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        var result = "";
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            result = await Task.FromResult($"{args.Result[0].Text}");
        });
        WeakReferenceMessenger.Default.Send(new MyMessage("Hello World"));
        await DisplayAlert("", $"Result: {result}","Ok");
    }

}