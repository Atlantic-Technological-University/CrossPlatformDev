# Week five: Implementing the MVVM design pattern in .NET MAUI  

In week five of the module we explore how to implement the Model View ViewModel (MVVM) design pattern in a .NET MAUI Application.

## Repository content  

The demo code creates a simple .NET MAUI application that displays a list of contacts loaded from a PeopleService class. A ViewModel class calls on the PeopleService class which loads the data from a local JSON file and returns the data to the ViewModel. The PeopleSerivce could be modified to make either database or REST calls if necessary. Once the ViewModel has obtained the data, .NET data bindings are used between the View and ViewModel to synchronise data within the application.

A full set of instructional videos demonstrating how to implement this application from a .NET MAUI starter project is available in the module area in blackboard.  

If you notice any issues or errors create an issue or better still offer a solution and create a pull-request.  
