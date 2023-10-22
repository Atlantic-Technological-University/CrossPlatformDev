using System;
using System.Collections.Generic;
using SimpleDI.Model;

namespace SimpleDI.Service;

public class FileContactDataService : IContactDataService
{
    public List<Person> GetContacts()
    {
        return new List<Person>
        {
            new Person {ID = 1, FirstName = "Derek", LastName = "Cleese"},
            new Person {ID = 2, FirstName = "Jane", LastName = "Austin"},
            new Person {ID = 3, FirstName = "Frank", LastName = "Smith"},
            new Person {ID = 4, FirstName = "Lucy", LastName = "Doherty"},
            new Person {ID = 5, FirstName = "John", LastName = "McLaughlin"},
            new Person {ID = 6, FirstName = "Dot", LastName = "South"},
        };
    }
}



public class DBContactDataService : IContactDataService
{
    public List<Person> GetContacts()
    {
        return new List<Person>
        {
            new Person {ID = 1, FirstName = "Derek", LastName = "Cleese"},
            new Person {ID = 2, FirstName = "Jane", LastName = "Austin"},
            new Person {ID = 3, FirstName = "Frank", LastName = "Smith"},
            new Person {ID = 4, FirstName = "Lucy", LastName = "Doherty"},
            new Person {ID = 5, FirstName = "John", LastName = "McLaughlin"},
            new Person {ID = 6, FirstName = "Dot", LastName = "South"},
        };
    }
}


public class WebContactDataService : IContactDataService
{
    public List<Person> GetContacts()
    {
        Console.WriteLine("-- Using WebContactDataService --");
        return new List<Person>
        {
            new Person {ID = 1, FirstName = "Derek", LastName = "Cleese"},
            new Person {ID = 2, FirstName = "Jane", LastName = "Austin"},
            new Person {ID = 3, FirstName = "Frank", LastName = "Smith"},
            new Person {ID = 4, FirstName = "Lucy", LastName = "Doherty"},
            new Person {ID = 5, FirstName = "John", LastName = "McLaughlin"},
            new Person {ID = 6, FirstName = "Dot", LastName = "South"},
        };
    }
}

public class TestContactDataService : IContactDataService
{
    public List<Person> GetContacts()
    {
        Console.WriteLine("-- Using TestContactDataService --");
        return new List<Person>
        {
            new Person {ID = 1, FirstName = "Derek", LastName = "Cleese"},
            new Person {ID = 2, FirstName = "Jane", LastName = "Austin"},
            new Person {ID = 3, FirstName = "Frank", LastName = "Smith"},
            new Person {ID = 4, FirstName = "Lucy", LastName = "Doherty"},
            new Person {ID = 5, FirstName = "John", LastName = "McLaughlin"},
            new Person {ID = 6, FirstName = "Dot", LastName = "South"},
        };
    }
}


public static class DataServiceFactory
{
    public static bool TestMode;

    public static IContactDataService GetDataService()
    {
        if (TestMode)
        {
            //Return the test data service
            return new TestContactDataService();
        }
        else
        {
            //Return the live data service
            return new WebContactDataService();
        }
        
    }
}