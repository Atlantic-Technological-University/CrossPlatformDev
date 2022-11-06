using URIParams.Pages;

namespace URIParams;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //Register routes
        Routing.RegisterRoute("deciduous", typeof(DeciduousPage));
        Routing.RegisterRoute("deciduousNative", typeof(DeciduousNative));
        Routing.RegisterRoute("Beech", typeof(Beech));
        Routing.RegisterRoute("Oak", typeof(Oak));
        Routing.RegisterRoute("deciduousNonNative", typeof(DeciduousNonNative));
        
        // Navigation in this sample code is a mixture between GoToAsync and PushAsync
        Routing.RegisterRoute("evergreen", typeof(EverGreenPage));
        Routing.RegisterRoute("evergreen/evergreenNative", typeof(Oak));
        

    }
}
