using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.DataModels;
using Labb3_NET22.Managers;

namespace Labb3_NET22.ViewModel;

public class StartViewModel : ObservableObject
{
    public IRelayCommand NavigateCreateQuizCommand { get; }
    public IRelayCommand NavigatePlayQuizCommand { get; }

    private readonly NavigationManager _navigationManager;
    private readonly QuizModel _quizModel;
    public StartViewModel( QuizModel quizModel, NavigationManager navigationManager)
    {
        _quizModel = quizModel;
        _navigationManager = navigationManager;

        NavigateCreateQuizCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new CreateQuizViewModel(_quizModel, _navigationManager));

        NavigatePlayQuizCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new ChooseQuizViewModel(_quizModel, _navigationManager));
    }
}