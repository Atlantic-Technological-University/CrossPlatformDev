using BankingTDD.Models;
using BankingTDD.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BankingTDD.ViewModels;

public partial class TransactionsViewModel : BaseViewModel
{
    // A transaction service to retrieve transactions
    ITransactionService _transactionService;

    // An observable collection of transactions for the view
    public ObservableCollection<Transaction> Transactions { get; } = new();

    string _accountNumber;

    public string AccountNumber
    {
        get => _accountNumber;
        set
        {
            _accountNumber = value;
            OnPropertyChanged();
        }
    }
    // Obserable properties for the date picker in the view. The date pickers are used to 
    // specify the dates between which transactions should be retrieved.
    [ObservableProperty]
    DateTime _minDate;

    [ObservableProperty]
    DateTime _maxDate;

    [ObservableProperty]
    DateTime _selectedStartDate;

    [ObservableProperty]
    DateTime _selectedEndDate;

    // A command for the view to retrieve transactions
    public Command GetTransactions { get; }


    /// <summary>
    /// The constructor for the TransactionsViewModel initialises the command and transaction 
    /// service. It also initialises the various dates for the date pickers for the view.
    /// </summary>
    /// <param name="transactionService"></param>
    public TransactionsViewModel(ITransactionService transactionService)
    {
        _transactionService = transactionService;
        _minDate = DateTime.Now.AddMonths(-6);
        _maxDate = DateTime.Now;
        _selectedStartDate = DateTime.Now.AddDays(-30);
        _selectedEndDate = DateTime.Now; 


        // Initialise the command to retrieve transactions
        GetTransactions = new Command(async () => await GetTransactionsAsync(SelectedStartDate, SelectedEndDate));
    }

    async Task GetTransactionsAsync(DateTime startDateTimePeriod, DateTime endDateTimePeriod) 
    {
        // If we are already busy just return to prevent the user spamming the button
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            var transactions = await _transactionService.GetTransactions(_accountNumber, startDateTimePeriod, endDateTimePeriod);
            if (transactions.Count != 0)
                Transactions.Clear();

            foreach (var transaction in transactions)
            {
                // This will create notification every time we add a monkey to the observable collection
                // .NET 7 might have an add range to add items in a batch
                Transactions.Add(transaction);
            }
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // The display alert is really a UI call which doesn't fit into the viewmodel pattern
            // We could abstract this and create an interface that injects the message/alert
            await Shell.Current.DisplayAlert("Error", $"Unable to get transactions for account {_accountNumber}", "OK");
        }
        finally
        {
            // Finally always gets called
            IsBusy = false;
        }

    }

}
