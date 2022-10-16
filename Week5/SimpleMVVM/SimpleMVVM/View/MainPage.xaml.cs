using SimpleMVVM.ViewModel;

namespace SimpleMVVM;

public partial class MainPage : ContentPage
{
	public MainPage(PeopleViewModel viewModel)
	{
		InitializeComponent();

		// Set the binding context to the viewModel
		BindingContext = viewModel;
	}

	
}

