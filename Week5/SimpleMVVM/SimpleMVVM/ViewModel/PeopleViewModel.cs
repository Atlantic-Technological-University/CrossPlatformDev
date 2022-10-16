using SimpleMVVM.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SimpleMVVM.ViewModel;

public class PeopleViewModel : BaseViewModel
{
    // A people service that retrieves a list of people from somewhere
    PeopleService _peopleService;

    // A collection to store the people
    public ObservableCollection<Model.Person> People { get; } = new();

    // Create a GetPeopleCommand that the view can use to get people
    public Command GetPeopleCommand { get; }

    // Constructor for the PeopleViewModel initialises the PeopleService and the GetPeopleCommand
    public PeopleViewModel(PeopleService peopleService)
    {
        _peopleService = peopleService;

        // Initialise the command telling it to call the GetPeople Task
        GetPeopleCommand = new Command(async () => await GetPeopleAsync());
    }

    // The GetPeopleAsync() task retrieves a list of people from the peopleService and add them to the People collection
    async Task GetPeopleAsync()
    {
        // if we are busy just return
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            //var people = await _peopleService.GetPeopleFileAsync();
            var people = await _peopleService.GetPeopleRemoteAsync();
            //
            if (people.Count != 0)
                People.Clear();

            foreach(var person in people)
            {
                People.Add(person);
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // Display an alert if an exception is raised
            await Shell.Current.DisplayAlert("Error", "Unable to get people", "OK");

        }
        finally
        {
            // Finish/clean up code in here
            IsBusy = false;
        }
    }
}
