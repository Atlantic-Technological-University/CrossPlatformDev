using BankingTDD.ViewModels;

namespace BankingTDD.Views;

public partial class TransactionsPage : ContentPage
{
    TransactionsViewModel _viewModel;

    public TransactionsPage(TransactionsViewModel viewModel)
	{
		InitializeComponent();
        
        // Set the binding context for the transactions page
        _viewModel = viewModel;
        BindingContext = viewModel;
        viewModel.AccountNumber = "1234567890";
    }

}