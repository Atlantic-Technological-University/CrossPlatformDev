using BankingTDD.Models;
using System.Diagnostics;
using System.Text.Json;


namespace BankingTDD.Services;

/// <summary>
/// Test Double for the ITransactionService interface, retrieves a list of account transactions
/// from a JSON file.
/// </summary>
public class FileTransactionService : ITransactionService
{
    List<Transaction> _transactions = new List<Transaction>();

    public class tempTransaction
    {
        public string AccountNumber { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }
        public string TransactionType { get; set; }
        public string Notes { get; set; }
    }


    /// <summary>
    /// Reads a list of transactions from file retrieving those transactions that match the given 
    /// account number.
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <returns></returns>
    public async Task<List<Transaction>> GetTransactions(string accountNumber)
    {
        // Todo - implement the GetTransactions method
        throw new NotImplementedException();
    }

    /// <summary>
    /// Reads a list of transactions from file retrieving those transactions that match the given 
    /// account number and are between the start and end DateTimePeriod.
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <returns></returns>
    public async Task<List<Transaction>> GetTransactions(string accountNumber, DateTime startDateTimePeriod, DateTime endDateTimePeriod)
    {
        // Todo - implement the GetTransactions method
        throw new NotImplementedException();
    }



    /// <summary>
    /// Removes transactions that do not match the account number.
    /// </summary>
    /// <param name="accountNumber">The account number to match.</param>
    /// <returns></returns>
    private List<Transaction> RemoveTransactionsNotMatchingAccountNumber(string accountNumber)
    {
        // Todo - implement the RemoveTransactionsNotMatchingAccountNumber method
        throw new NotImplementedException();
    }

    /// <summary>
    /// Removes any transactions that do not fall between a start and end date.
    /// </summary>
    /// <param name="startDateTimePeriod">Start date and time.</param> 
    /// <param name="endDateTimePeriod">End date and time.</param>
    /// <returns></returns>
    private List<Transaction> RemoveTransactionsNotBetweenDates(DateTime startDateTimePeriod, DateTime endDateTimePeriod)
    {
        // Todo - implement the RemoveTransactionsNotBetweenDates method
        throw new NotImplementedException();
    }
}
