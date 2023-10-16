namespace NavPageDemo;

public partial class RootPage : ContentPage
{
	public RootPage()
	{
		InitializeComponent();
		btnNavigateToNext.Clicked += OnbtnNavigateToNext_Clicked;

    }

	private async void OnbtnNavigateToNext_Clicked(object sender, EventArgs e)
	{
		// Push a new page onto the stack
		await Navigation.PushAsync(new NewPage1(1));
	}
}