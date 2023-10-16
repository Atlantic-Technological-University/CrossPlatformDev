namespace FlyoutPageNavDemo;

public partial class FlyMenuPage : ContentPage
{
	public FlyMenuPage()
	{
		InitializeComponent();
	}
}

public class FlyoutPageItem
{
	// Backing class for flyout page menu items
    public string Title { get; set; }
    public string IconSource { get; set; }
    public Type TargetType { get; set; }
}