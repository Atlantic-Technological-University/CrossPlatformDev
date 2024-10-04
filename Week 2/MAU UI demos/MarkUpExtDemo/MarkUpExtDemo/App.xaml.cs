namespace MarkUpExtDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

static class AppDefaults
{
    public static double NormalFontSize = 18;
    public static double XLFontSize = 60;
}