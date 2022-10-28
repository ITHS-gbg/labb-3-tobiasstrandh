using CommunityToolkit.Mvvm.ComponentModel;
using Labb3_NET22.DataModels;
using Labb3_NET22.Managers;

namespace Labb3_NET22.ViewModel;

public class QuizViewModel : ObservableObject
{
    private readonly QuizModel _quizModel;
    private readonly NavigationManager _navigationManager;
    public QuizViewModel (QuizModel quizModel, NavigationManager navigationManager)
    {
       
        _quizModel = quizModel;

        _navigationManager = navigationManager;
    }

    private string _quizStatment;

    public string QuizStatment
    {
        get { return _quizStatment = _quizModel.RandomQuestion.Statement; }
        set
        {
            SetProperty(ref _quizStatment, value);
        }
    }
}