namespace LoginUI1;

public partial class Login2 : ContentPage
{
	public Login2()
	{
		InitializeComponent();
	}

    private async void LoginButton_Clicked(object sender, EventArgs e)
	{
        await DisplayAlert("Login attempted", $"{userName.Text} attempted to login", "OK");
    }
}