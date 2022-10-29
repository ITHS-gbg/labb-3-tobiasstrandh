using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.DataModels;
using Labb3_NET22.Managers;

namespace Labb3_NET22.ViewModel;

public class ChooseQuizViewModel : ObservableObject
{
    private readonly QuizModel _quizModel;
    private readonly NavigationManager _navigationManager;

    public ICommand ReturnToStartViewCommand { get; }
    public ICommand GoToQuizViewCommand { get; }

    public ICommand SaveTitleCommand { get; }
    public ChooseQuizViewModel(QuizModel quizModel, NavigationManager navigationManager)
    {

        _quizModel = quizModel;
        _navigationManager = navigationManager;


        ReturnToStartViewCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new StartViewModel(_quizModel, _navigationManager));

        
        
        GoToQuizViewCommand = new RelayCommand(() => GoToQuizView());

    }

    public async Task GoToQuizView()
    {
        _quizModel.DownloadJson(QuizTitle);
        await Task.Delay(100);
        _quizModel.GetRandomQuestion();
        await Task.Delay(100);
        _navigationManager.CurrentViewModel = new QuizViewModel(_quizModel, _navigationManager);
    }


    private string _quizTitle;

    public string QuizTitle
    {
        get { return _quizTitle; }
        set
        {
            SetProperty(ref _quizTitle, value);
        }
    }

}