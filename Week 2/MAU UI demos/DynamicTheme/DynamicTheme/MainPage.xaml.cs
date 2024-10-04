namespace DynamicTheme
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            SemanticScreenReader.Announce(CounterBtn.Text);

            //Get the application's current resourceDictionaries that were merged during build
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            if(mergedDictionaries !=null)
            {
                mergedDictionaries.Clear();
                mergedDictionaries.Add(new Resources.Styles.NewTheme());
            }

            //AppTheme currentTheme = Application.Current.RequestedTheme;
            

        }
    }

}
