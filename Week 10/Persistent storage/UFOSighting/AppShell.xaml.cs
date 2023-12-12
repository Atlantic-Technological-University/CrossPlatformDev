using UFOSighting.Views;
namespace UFOSighting;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        // Create an instance of the UFOEncounter page when you navigate to the UFOEncounter page
        Routing.RegisterRoute(nameof(EncounterPage), typeof(EncounterPage));
    }
}
