using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.DataModels;
using Labb3_NET22.Managers;

namespace Labb3_NET22.ViewModel;

public class StartViewModel : ObservableObject
{
    public IRelayCommand NavigateCreateQuizCommand { get; }
    public IRelayCommand NavigatePlayQuizCommand { get; }
    public IRelayCommand NavigateEditQuizCommand { get; }

    private readonly NavigationManager _navigationManager;
    private readonly QuizManger _quizManger;
    private readonly QuizModel _quizModel;
    public StartViewModel( QuizManger quizManger, NavigationManager navigationManager)
    {
        _quizManger = quizManger;
        _navigationManager = navigationManager;
        _quizModel = _quizManger.CurrentQuiz;
        DefaultQuiz();

        


        NavigateCreateQuizCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new CreateQuizViewModel(_quizManger, _navigationManager));

        NavigatePlayQuizCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new ChooseQuizViewModel(_quizManger, _navigationManager));

        NavigateEditQuizCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new EditViewModel(_quizManger, _navigationManager));
    }

    

    private async Task DefaultQuiz()
    {
        _quizManger.CurrentQuiz = new QuizModel("tobbesquiz");

        await _quizManger.CurrentQuiz.Pop();

        await Task.Run((() => _quizManger.JsonDefault()));
        
    }

}