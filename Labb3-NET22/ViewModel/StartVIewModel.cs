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
        _quizManger.CurrentQuiz.ClearQuestions();
        //_quizManger.JsonTitleList();
        _quizManger.CurrentQuiz.RandomNum.Clear();


        NavigateCreateQuizCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new CreateQuizViewModel(_quizManger, _navigationManager));

        NavigatePlayQuizCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new ChooseQuizViewModel(_quizManger, _navigationManager));

        NavigateEditQuizCommand = new RelayCommand(() => EditView());
    }

    

    private async Task DefaultQuiz()
    {

        _quizManger.CurrentQuiz.PopulateDefaultQuiz();
        //_quizManger.CurrentQuiz.AddTitle("tobbesquiz");
        await Task.Run((() => _quizManger.JsonDefault()));
        //_navigationManager.CurrentViewModel = new ChooseQuizViewModel(_quizManger, _navigationManager)




    }

    public async Task EditView()
    {
        //_quizManger.CurrentQuiz.AddTitle("tobbesquiz");
        //_quizManger.DownloadJson();
        await Task.Delay(100);
        _navigationManager.CurrentViewModel = new EditViewModel(_quizManger, _navigationManager);

    }
}