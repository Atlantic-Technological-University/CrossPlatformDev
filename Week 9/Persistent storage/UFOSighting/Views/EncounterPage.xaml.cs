using UFOSighting.ViewModels;

namespace UFOSighting.Views;

public partial class EncounterPage : ContentPage
{
	public EncounterPage(EncounterViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}