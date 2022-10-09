namespace URIParams.Pages;

public partial class EverGreenPage : ContentPage
{
	public EverGreenPage()
	{
		InitializeComponent();

        ImgEvergreenNative.Clicked += OnImgEvergreenNative_Clicked;
        ImgEvergreenNonNative.Clicked += OnImgEvergreenNonNative_Clicked;
    }

    private async void OnImgEvergreenNative_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Not implemented", "Sorry this feature has not been implemented yet.", "OK");
    }

    private async void OnImgEvergreenNonNative_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Not implemented", "Sorry this feature has not been implemented yet.", "OK");
    }
}