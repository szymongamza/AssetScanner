namespace AssetScanner;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(AssetInfoPage), typeof(AssetInfoPage));
	}
}
