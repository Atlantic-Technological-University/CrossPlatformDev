using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimpleMVVM.ViewModel;


public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool _isBusy;
    [ObservableProperty]
    string _pageTitle;

    public bool IsNotBusy => !IsBusy;
}
