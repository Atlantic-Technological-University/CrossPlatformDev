using System;
using System.Collections.Generic;

using SimpleDI.Model;
using SimpleDI.Service;

namespace SimpleDI;

public class ContactFinder
{
    private IContactDataService _dataService;

    public ContactFinder(IContactDataService dataService)
    {
        _dataService = dataService;
    }


    /*public ContactFinder()
    {
        _dataService = DataServiceFactory.GetDataService();
    }*/
    public List<Person> GetContactsBy(string name)
    {
        //List<Person> contacts = new ContactDataService().GetContacts();
        List<Person> contacts = _dataService.GetContacts();
        //foreach (Person contact in contacts)
        for (int i = contacts.Count - 1; i >= 0; i--)
        {
            if (!contacts[i].FirstName.Contains(name))
            {
                contacts.RemoveAt(i);
            }
        }
        return contacts;
    }
}
