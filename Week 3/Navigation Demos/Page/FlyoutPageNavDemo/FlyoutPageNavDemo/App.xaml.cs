namespace FlyoutPageNavDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new AppShell();
		MainPage = new FlyoutPageNavigation();
	}
}


/*
 * If we want to change the colour of the navigation bar text and background colour add this
 * 
    <Application.Resources>
        <ResourceDictionary>
            <Color x:Key="PrimaryColor">#242A75</Color>
            <Color x:Key="SecondaryColor">White</Color>

            <Style TargetType="NavigationPage">
                <Setter Property="BarBackgroundColor" Value="Black"></Setter>
                <Setter Property="BarTextColor" Value="{DynamicResource SecondaryColor}" />
            </Style>
        </ResourceDictionary>
    </Application.Resources>

 
 */