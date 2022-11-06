using URIParams.Model;

namespace URIParams.Pages;

public partial class DeciduousPage : ContentPage
{
	public DeciduousPage()
	{
		InitializeComponent();

        ImgDeciduousNative.Clicked += OnImgDeciduousNative_Clicked;
        ImgDeciduousNonNative.Clicked += OnImgDeciduousNonNative_Clicked;
    }

    private async void OnImgDeciduousNative_Clicked(object sender, EventArgs e)
	{
        await DisplayAlert("Not implemented", "Sorry this feature has not been implemented yet.", "OK");
    }

    private async void OnImgDeciduousNonNative_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Not implemented", "Sorry this feature has not been implemented yet.", "OK");
    }
}