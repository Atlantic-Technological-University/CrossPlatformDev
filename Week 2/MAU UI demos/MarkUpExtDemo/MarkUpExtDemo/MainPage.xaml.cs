namespace MarkUpExtDemo;

public partial class MainPage : ContentPage
{
	public const double MyFontSize = 25;
    public MainPage()
	{
		InitializeComponent();

		btnChangeText.Clicked += OnbtnChangeTextClicked;

    }

	private void OnbtnChangeTextClicked(object sender, EventArgs e)
	{
		lblText.Text = "New message";

    }
}

public class GlobalFontSizeExtension : IMarkupExtension
{
	public object ProvideValue(IServiceProvider serviceProvider)
	{
		return MainPage.MyFontSize;
	}
}

