using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetScanner;

public partial class AssetPage : ContentPage
{
    public string QRCode { get; set;}
    public AssetPage(string qrcode)
    {
        InitializeComponent();
        QRCode = qrcode;
        TempLabel.Text = qrcode;
    }


}