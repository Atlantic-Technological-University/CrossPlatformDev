using ShellNavigationDemo.Pages;

namespace ShellNavigationDemo;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        btnDeciduous.Clicked += OnbtnDeciduous_Clicked;
        btnEverGreen.Clicked += OnbtnEverGreen_Clicked;
        btnOak.Clicked += OnbtnOak_Clicked;
                
        // Register routes
        Routing.RegisterRoute("deciduous", typeof(DeciduousPage));
        //Routing.RegisterRoute("evergreen", typeof(EverGreenPage));
    }

    private async void OnbtnDeciduous_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("deciduous");
        
    }

    private async void OnbtnEverGreen_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("evergreen");
    }

    private async void OnbtnOak_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Oak");
    }


    

    /*
	 
    [ICommand]
    Task Navigate() => 
        Shell.Current.GoToAsync($"{nameof(DetailPage)}?Count={Count}",
	 */
}

