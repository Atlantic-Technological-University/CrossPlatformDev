using ShellNavigationDemo.Pages;

namespace ShellNavigationDemo;


public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("evergreen", typeof(EverGreenPage));

        // Example of Registering routes with hierarchies
        
         
        Routing.RegisterRoute("evergreen", typeof(EverGreenPage));
        Routing.RegisterRoute("evergreen/evergreenNative", typeof(EvergreenNative));
        Routing.RegisterRoute("evergreen/evergreenNative/ScotsPine", typeof(ScotsPine));
        Routing.RegisterRoute("evergreen/evergreenNonNative", typeof(EverGreenNonNative));
        Routing.RegisterRoute("evergreen/evergreenNonNative/CoastRedwood", typeof(CoastRedwood));
        Routing.RegisterRoute("evergreen/evergreenNonNative/GiantRedwood", typeof(GiantRedwood));

        Routing.RegisterRoute("deciduous", typeof(DeciduousPage));
        Routing.RegisterRoute("deciduous/deciduousNative", typeof(DeciduousNative));
        Routing.RegisterRoute("deciduous/deciduousNative/Oak", typeof(Oak));
        Routing.RegisterRoute("deciduous/deciduousNonNative", typeof(DeciduousNonNative));
        Routing.RegisterRoute("deciduous/deciduousNonNative/", typeof(DawnRedwood));

         
         

    }
}
