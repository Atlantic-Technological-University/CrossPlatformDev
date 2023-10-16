namespace NavPageDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new AppShell();

		// Create a new navigation page
		MainPage = new NavigationPage(new RootPage());
	}
}
