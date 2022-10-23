using CommunityToolkit.Mvvm.ComponentModel;

namespace Labb3_NET22.ViewModel;

public class MainViewModel
{
    public ObservableObject CurrentViewModel { get; }

    public MainViewModel(ObservableObject currentViewModel)
    {
        CurrentViewModel = currentViewModel;
    }
}