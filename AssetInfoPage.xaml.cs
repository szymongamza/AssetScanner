using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camera.MAUI.ZXingHelper;

namespace AssetScanner;

public partial class AssetInfoPage : ContentPage
{
    private bool isAssetPageOpen = false;
    public AssetInfoPage()
    {
        InitializeComponent();
    }

    private void CameraView_OnCamerasLoaded(object sender, EventArgs e)
    {
        if (CameraView.Cameras.Count > 0)
        {
            CameraView.Camera = CameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await CameraView.StopCameraAsync();
                await CameraView.StartCameraAsync();
            });
        }
    }

    private void CameraView_OnBarcodeDetected(object sender, BarcodeEventArgs args)
    {

        if (!isAssetPageOpen)
        {
            isAssetPageOpen = true;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                var assetPage = new AssetPage(args.Result[0].Text);
                assetPage.Disappearing += (s, e) => { isAssetPageOpen = false; };
                Navigation.PushAsync(assetPage);
            });
        }
    }
}