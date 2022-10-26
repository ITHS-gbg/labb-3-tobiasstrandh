using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Labb3_NET22.DataModels;
using CommunityToolkit.Mvvm.Input;

namespace Labb3_NET22.ViewModel;

public class CreateQuizViewModel : ObservableObject
{
    public ICommand SendQuestion { get; }

    private readonly QuizModel _quizModel;

    private readonly QuestionModel _questionModel;
    public CreateQuizViewModel(QuizModel quizModel)
    {
        _quizModel = quizModel;

        SendQuestion = new RelayCommand(() => _quizModel.AddQuestion(QuizStatment, QuizCorrectAnswer, QuizAnswers));
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

    private string _quizStatment;

    public string QuizStatment
    {
        get { return _quizStatment; }
        set
        {
            SetProperty(ref _quizStatment, value);
        }
    }

    private string _quizAnswerOne;

    public string QuizAnswerOne
    {
        get { return _quizAnswerOne; }
        set
        {
            SetProperty(ref _quizAnswerOne, value);
        }
    }

    private string _quizAnswerThree;

    public string QuizAnswerThree
    {
        get { return _quizAnswerThree; }
        set
        {
            SetProperty(ref _quizAnswerThree, value);
        }
    }

    private string _quizAnswerTwo;

    public string QuizAnswerTwo
    {
        get { return _quizAnswerTwo; }
        set
        {
            SetProperty(ref _quizAnswerTwo, value);
        }
    }

    private string[] _quizAnswers;

    public string[] QuizAnswers
    {
        get { return _quizAnswers; }
        set
        {
            
        }
    }

    private int _quizCorrectAnswer;

    public int QuizCorrectAnswer
    {
        get { return _quizCorrectAnswer; }
        set
        {
            SetProperty(ref _quizCorrectAnswer, value);
        }
    }

   
}
