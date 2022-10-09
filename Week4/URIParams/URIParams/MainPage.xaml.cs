using System.Text.Json;
using URIParams.Model;
using URIParams.Pages;

namespace URIParams;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		ImgDeciduous.Clicked += OnImgDeciduous_Clicked;
		ImgEvergreen.Clicked += OnImgEvergreen_Clicked;
    }

	private async void OnImgEvergreen_Clicked(object sender, EventArgs e)
	{
        // Load the tree data from the JSON file in the Resources\Raw folder
        var json = await LoadTreeData();
        Trees treeData = JsonSerializer.Deserialize<Trees>(json);

        await this.Navigation.PushAsync(new EverGreenPage());
    }

	private async void OnImgDeciduous_Clicked(object sender, EventArgs e)
	{
        // Load the tree data from the JSON file in the Resources\Raw folder
        var json = await LoadTreeData();
        Trees treeData = JsonSerializer.Deserialize<Trees>(json);
        
        await this.Navigation.PushAsync(new DeciduousPage());
    }

    async Task<string> LoadTreeData()
    {
        try
        {
            // Attempt to read the tree data in the json file in the resources\raw folder.
            using var stream = await FileSystem.OpenAppPackageFileAsync("trees.json");
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}

