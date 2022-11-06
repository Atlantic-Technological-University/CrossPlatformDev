namespace URIParams.Pages;

public partial class Oak : ContentPage
{
	public Oak()
	{
		InitializeComponent();

		btnBack.Clicked += OnbtnBack_Clicked;
		btnEvergreen.Clicked += OnbtnEvergreen_Clicked;

    }

	private async void OnbtnEvergreen_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("evergreen");
	}

	private async void OnbtnBack_Clicked(object sender, EventArgs e)
	{
		//This jumps back up the stack to the page we just came from
        await Shell.Current.GoToAsync("//MainPage");
    }    
}