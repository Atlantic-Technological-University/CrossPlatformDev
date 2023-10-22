using System;
using System.Collections.Generic;
using SimpleDI.Model;

namespace SimpleDI.Service;

public interface IContactDataService
{
    //List<Transaction> GetTransaction(string accountNumber);
    List<Person> GetContacts();
    
}
