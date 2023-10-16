
namespace ShellNavigationDemo.Pages;

public partial class DeciduousPage : ContentPage
{
	public DeciduousPage()
	{
		InitializeComponent();

        ImgEvergreen.Clicked += OnImgEvergreen_Clicked;
        ImgDeciduous.Clicked += OnImgDeciduous_Clicked;

    }

	private void OnImgEvergreen_Clicked(object sender, EventArgs e)
	{
		
	}

    private void OnImgDeciduous_Clicked(object sender, EventArgs e)
    {
        //await Shell.Current.GoToAsync("deciduous");
    }

    
}