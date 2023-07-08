using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetScanner.Model;
using AssetScanner.Services;
using Microsoft.Maui.Controls;

namespace AssetScanner;

public partial class AssetPage : ContentPage
{
    private List<AssetResource> _assetResources;

    public AssetPage(List<AssetResource> assetResources)
    {
        InitializeComponent();
        _assetResources = assetResources;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var asset = _assetResources.First();
        Name.Text = asset.Name;
        Model.Text = asset.Model;
    }


}