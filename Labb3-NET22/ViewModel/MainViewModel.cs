using CommunityToolkit.Mvvm.ComponentModel;
using Labb3_NET22.Managers;

namespace Labb3_NET22.ViewModel;
 

public class MainViewModel : ObservableObject
{
    private readonly NavigationManager _navigationManager;
    private readonly DataManger _dataManager;

    public ObservableObject CurrentViewModel => _navigationManager.CurrentViewModel;


    public MainViewModel(NavigationManager navigationManager, DataManger dataManager)
    {
        _navigationManager = navigationManager;
        _dataManager = dataManager;

        _navigationManager.CurrentViewModelChanged += CurrentViewModelChanged;
    }

    private void CurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}