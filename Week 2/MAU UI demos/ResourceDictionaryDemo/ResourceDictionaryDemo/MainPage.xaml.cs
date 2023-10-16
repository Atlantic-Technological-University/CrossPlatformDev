namespace ResourceDictionaryDemo;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		btnChangeColour.Clicked += OnBtnChangeColour_Clicked;

    }

	private void OnBtnChangeColour_Clicked(object sender, EventArgs e)
	{
		Resources["boxColour2"] = Color.FromRgb(184, 65, 45);
	}
}

