// See https://aka.ms/new-console-template for more information
using SimpleDI;
using SimpleDI.Model;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleDI.Service;

Console.WriteLine("Dependency injection");

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddTransient<IContactDataService, WebContactDataService>();
        services.AddTransient<IContactDataService, TestContactDataService>();
        services.AddTransient<ContactFinder>();


        //services.AddTransient<WebContactDataService>();
        //services.AddTransient<TestContactDataService>();

        //services.AddTransient<IContactDataService, WebContactDataService>(p => p.GetRequiredService<WebContactDataService>());
        //services.AddTransient<IContactDataService, TestContactDataService>(p => p.GetRequiredService<TestContactDataService>());
        //services.AddTransient<ContactFinder>();
    })
    
    .Build();

//ContactFinder contactFinder = new ContactFinder();
//List<Person> contacts = contactFinder.GetContactsBy("John");


using IServiceScope scope = host.Services.CreateScope();
IServiceProvider provider = scope.ServiceProvider;


ContactFinder contactFinder = provider.GetRequiredService<ContactFinder>();
List<Person> contacts = contactFinder.GetContactsBy("John");

Console.WriteLine($"We have {contacts.Count} contacts meeting our search criteria");


/*
// Get an enumeration of all services 
var services = provider.GetServices<IContactDataService>(); //Get all of the services
 
 */