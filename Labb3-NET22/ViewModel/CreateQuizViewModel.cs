using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Labb3_NET22.DataModels;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.Managers;

namespace Labb3_NET22.ViewModel;

public class CreateQuizViewModel : ObservableObject
{
    public ICommand SendQuestion { get; }
    public ICommand CreateJson { get; }
    public ICommand ReturnToStartViewCommand { get; }

    private readonly QuizModel _quizModel;

    private readonly QuestionModel _questionModel;

    private readonly NavigationManager _navigationManager;
    public CreateQuizViewModel(QuizModel quizModel, NavigationManager navigationManager)
    {
        _quizModel = quizModel;

        _navigationManager = navigationManager;

        SendQuestion = new RelayCommand(AddQ);

        CreateJson = new RelayCommand(() => _quizModel.Json());

        ReturnToStartViewCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new StartViewModel(_quizModel, _navigationManager));
    }

    private string _q;

    public string Q
    {
        get { return _q; }
        set { _q = value; }
    }


    void AddQ()
    {
        //var QuizAnswers = new string[] { QuizAnswerOne, QuizAnswerTwo, QuizAnswerThree };

        Correct();

        _quizModel.AddQuestion(QuizStatment, QuizCorrectAnswer, QuizAnswers);
    }

    public int QuizCorrectAnswer { get; set; }
    void Correct()
    {
        if (CorrectAnswerOne == true)
        {
            QuizCorrectAnswer = 0;
        }

        else if (CorrectAnswerTwo == true)
        {
            QuizCorrectAnswer = 1;
        }

        else if (CorrectAnswerThree == true)
        {
            QuizCorrectAnswer = 2;
        }
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
        get { return QuizAnswers[0]; } 
        set
        {
            SetProperty(ref QuizAnswers[0], value);
        }
    }

    private string _quizAnswerTwo;

    public string QuizAnswerTwo
    {
        get { return QuizAnswers[1]; }
        set
        {
            SetProperty(ref QuizAnswers[1], value);
        }
    }

    private string _quizAnswerThree;

    public string QuizAnswerThree
    {
        get { return QuizAnswers[2]; }
        set
        {
            SetProperty(ref QuizAnswers[2], value);
        }
    }

    

    


    private bool _correctAnswerOne;

    public bool CorrectAnswerOne
    {
        get { return _correctAnswerOne; }
        set
        {
            SetProperty(ref _correctAnswerOne, value);
        }
    }

    private bool _correctAnswerTwo;

    public bool CorrectAnswerTwo
    {
        get { return _correctAnswerTwo; }
        set
        {
            SetProperty(ref _correctAnswerTwo, value);
        }
    }

    private bool _correctAnswerThree;

    public bool CorrectAnswerThree
    {
        get { return _correctAnswerThree; }
        set
        {
            SetProperty(ref _correctAnswerThree, value);
        }
    }

    private string[] _quizAnswers = new string[3];

    public string[] QuizAnswers
    {
        get{ return _quizAnswers; }
    }

    //public static void AllAnswers(string QuizAnswerOne, string QuizAnswerTwo, string QuizAnswerThree, out string[] qAnswers)
    //{
    //    qAnswers = new string[] { QuizAnswerOne , QuizAnswerTwo, QuizAnswerThree };

    //    //quizAnswers[0] = QuizAnswerOne;
    //    //quizAnswers[1] = QuizAnswerTwo;
    //    //quizAnswers[2] = QuizAnswerThree;

    //    //qAnswers 
    //}

}
