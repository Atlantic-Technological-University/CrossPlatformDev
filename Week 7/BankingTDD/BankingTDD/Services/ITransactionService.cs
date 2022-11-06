using BankingTDD.Models;

namespace BankingTDD.Services;

public interface ITransactionService
{
    Task<List<Transaction>> GetTransactions(string accountNumber, DateTime startDateTimePeriod, DateTime endDateTimePeriod);

    Task<List<Transaction>> GetTransactions(string accountNumber);

    /*public void AddTransaction(Transaction transaction)
    {
        // TODO Add the transaction to the database
    }*/
}
