namespace ShellNavigationDemo.Pages;

public partial class EvergreenNative : ContentPage
{
	public EvergreenNative()
	{
		InitializeComponent();

		btnBackNew.Clicked += OnbtnBackNew_Clicked;
        btnBack.Clicked += OnbtnBack_Clicked;
        btnBack.Clicked += OnbtnBackForward_Clicked;

    }

	private async void OnbtnBack_Clicked(object sender, EventArgs e)
	{
        // We can navigate backwards by specifing ".."
        await Shell.Current.GoToAsync("..");
        
    }

    private async void OnbtnBackForward_Clicked(object sender, EventArgs e)
    {
        // We can navigate backwards and then forwards 
        await Shell.Current.GoToAsync("../evergreenNonNative/CoastRedwood");

        //await Shell.Current.GoToAsync("../../deciduous/deciduousNative");
    }

    private async void OnbtnBackNew_Clicked(object sender, EventArgs e)
	{
        // This will create a new evergreen page
        await Shell.Current.GoToAsync("evergreen");
    }


}