namespace MyMAUIApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        // MainPage = new AppShell();
        // This approach is obselete see: https://learn.microsoft.com/en-us/dotnet/maui/whats-new/dotnet-9?view=net-maui-9.0
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
