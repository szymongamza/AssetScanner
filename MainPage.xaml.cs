using Android.App;
using Camera.MAUI.ZXingHelper;

namespace AssetScanner;

public partial class MainPage : ContentPage
{

    public MainPage()
	{
		InitializeComponent();
    }

    private void StocktakingsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StocktakingsPage());
    }

    private void AssetInfoButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AssetInfoPage());
    }



    //private void cameraView_CamerasLoaded(object sender, EventArgs e)
    //{
    //    if (cameraView.Cameras.Count > 0)
    //    {
    //        cameraView.Camera = cameraView.Cameras.First();
    //        MainThread.BeginInvokeOnMainThread(async () =>
    //        {
    //            await cameraView.StopCameraAsync();
    //            await cameraView.StartCameraAsync();
    //        });
    //    }
    //}
    //
    //private void CameraView_OnBarcodeDetected(object sender, BarcodeEventArgs args)
    //{
    //    MainThread.BeginInvokeOnMainThread(() =>
    //    {
    //        barcodeResult.Text = $"ODCZYTANY KOD QR: {args.Result[0].Text}";
    //    });
    //}
}

