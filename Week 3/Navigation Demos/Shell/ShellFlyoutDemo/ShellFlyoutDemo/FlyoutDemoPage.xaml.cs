using System.Windows.Input;

namespace ShellFlyoutDemo;

public partial class FlyoutDemoPage : Shell
{
	public FlyoutDemoPage()
	{
		InitializeComponent();
		//aboutMenuItem.Clicked += OnAboutMenuItem_Clicked;

		Routing.RegisterRoute("mainpage", typeof(MainPage));

    }

  //  public ICommand ShowParametersCommand => new Command(ShowParametersControl);
  //  public void ShowParametersControl()
  //  {
		////AppShell.Current.CurrentItem???   <--- do something here?
		//AppShell.Current.CurrentItem = new MainPage();
  //  }
}