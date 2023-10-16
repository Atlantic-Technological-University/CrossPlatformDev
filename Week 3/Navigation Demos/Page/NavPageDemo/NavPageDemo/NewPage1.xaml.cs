namespace NavPageDemo;

public partial class NewPage1 : ContentPage
{
    public int PageNumber { get; set; }
    
	public NewPage1(int pagenum)
	{
		InitializeComponent();
        btnNavigateToNext.Clicked += OnbtnNavigateToNext_Clicked;
        btnNavigateToPrevious.Clicked += OnbtnNavigateToPrevious_Clicked;
        btnNavigateToRoot.Clicked += OnbtnNavigateToRoot_Clicked;
        btnRemovePage.Clicked += OnbtnRemovePage_Clicked;

        PageNumber = pagenum;
        this.Title = $"Page number {PageNumber}";

        this.PageLabel.Text=$"Welcome to new page {PageNumber}";
        Random random = new Random();
        
        this.BackgroundColor= Color.FromRgb(random.Next(255), random.Next(255), random.Next(255));

        if (PageNumber >= 4)
        {
            btnRemovePage.IsEnabled = true;
        }



    }

#if ANDROID
    protected override bool OnBackButtonPressed()
    {
        // Override the back button
        DisplayAlert("Disabled", "I'd like to help but meh", "OK");
        return false;
    }
#endif


    private void OnbtnRemovePage_Clicked(object sender, EventArgs e)
    {
        //Page thisPage = Navigation.NavigationStack[]
        this.Navigation.RemovePage(Navigation.NavigationStack[PageNumber - 1]);
        //Navigation.RemovePage()
        
    }

    private async void OnbtnNavigateToNext_Clicked(object sender, EventArgs e)
    {
        // Push a new page onto the Navigation stack
        //await Navigation.PushAsync(new NewPage1(PageNumber + 1));

        //await Navigation.PushModalAsync(new NewPage1(PageNumber + 1));

        await Navigation.PushModalAsync(new MainPage());

        await Navigation.PopModalAsync();

        //Turn off page Transition with false
        //await Navigation.PushAsync(new NewPage1(PageNumber + 1), false);
    }

    private async void OnbtnNavigateToPrevious_Clicked(object sender, EventArgs e)
    {
        // Pop this new page off Navigation the stack
        await Navigation.PopAsync();

        //Turn off page Transition with false
        //await Navigation.PopAsync(false);

        //Mention that you can 
        //await Navigation.PopModalAsync();
    }


    private async void OnbtnNavigateToRoot_Clicked(object sender, EventArgs e)
    {
        // Navigate to the root page
        await Navigation.PopToRootAsync();
    }

    

}