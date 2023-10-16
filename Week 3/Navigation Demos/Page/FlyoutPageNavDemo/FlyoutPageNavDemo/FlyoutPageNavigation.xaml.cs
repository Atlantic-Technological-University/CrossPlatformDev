 namespace FlyoutPageNavDemo;

public partial class FlyoutPageNavigation : FlyoutPage
{
	public FlyoutPageNavigation()
	{
		InitializeComponent();
        this.flyoutMenu.collectionView.SelectedItem = 1;
        string temp = this.flyoutMenu.collectionView.SelectedItem.ToString();
        this.flyoutMenu.collectionView.SelectionChanged += CollectionView_SelectionChanged;
	}

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
        if (item != null)
        {
            // Create the new detail page when the selected collection view (menu) items is changed
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
        }
    }
}

