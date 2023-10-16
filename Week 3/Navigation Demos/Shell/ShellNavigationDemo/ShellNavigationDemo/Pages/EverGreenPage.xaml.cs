namespace ShellNavigationDemo.Pages;

public partial class EverGreenPage : ContentPage
{
	public EverGreenPage()
	{
		InitializeComponent();

        ImgEvergreenNative.Clicked += OnImgEvergreenNative_Clicked;
        ImgEvergreenNonNative.Clicked += OnImgEvergreenNonNative_Clicked;

        //Register routes
        //Routing.RegisterRoute("evergreenNative", typeof(EvergreenNative)); *
        //Routing.RegisterRoute("evergreenNonNative", typeof(EverGreenNonNative)); *

    }

    private async void OnImgEvergreenNative_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("evergreenNative");
    }

    private async void OnImgEvergreenNonNative_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("evergreenNonNative");
    }
}