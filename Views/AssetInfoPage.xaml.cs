using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetScanner.Model;
using AssetScanner.Services;
using Camera.MAUI.ZXingHelper;
using ZXing.QrCode.Internal;

namespace AssetScanner;

public partial class AssetInfoPage : ContentPage
{
    private bool isAssetPageOpen = false;
    private IRestService _restService;
    public AssetInfoPage(IRestService restService)
    {
        _restService = restService;
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

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                var query = new AssetQueryResource { ItemsPerPage = 1, Page = 1, QRCode = Guid.Parse(args.Result[0].Text) };
                base.OnAppearing();
                var response = await _restService.GetAsset(query);

                var assetPage = new AssetPage(response.Items);
                assetPage.Disappearing += (s, e) => { isAssetPageOpen = false; };
                Navigation.PushAsync(assetPage);
            });
        }
    }
}