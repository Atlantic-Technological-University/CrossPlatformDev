using System.Globalization;
using UFOSighting.ViewModels;

namespace UFOSighting;

public partial class MainPage : ContentPage
{

	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();

        //Set the binding context
        BindingContext = viewModel;

    }

}

