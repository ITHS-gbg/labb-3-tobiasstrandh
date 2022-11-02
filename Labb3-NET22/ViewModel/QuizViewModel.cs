using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.DataModels;
using Labb3_NET22.Managers;

namespace Labb3_NET22.ViewModel;

public class QuizViewModel : ObservableObject
{
    private readonly QuizModel _quizModel;
    private readonly NavigationManager _navigationManager;
    private readonly QuizManger _quizManger;

    public ICommand NextQuestion { get; }

    public QuizViewModel (QuizManger quizManger, NavigationManager navigationManager)
    {

        _quizManger = quizManger;

        _navigationManager = navigationManager;

        NextQuestion = new RelayCommand(() => NextQ());
    }

    public async Task NextQ()
    {
        AmountAnswersTotal = AmountAnswersTotal + 1;

        if (AmountAnswersTotal == 10)
        {
            _navigationManager.CurrentViewModel = new StartViewModel(_quizManger, _navigationManager);
            
        }


        CanNextQuestion = false;
        //IsItCorrect();
        //CanFillBoxes = false;

        _quizManger.CurrentQuiz.GetRandomQuestion();

        #region stringEmpty
        QuizStatment = string.Empty;

        QuizAnswerOne = string.Empty;
        QuizAnswerTwo = string.Empty;
        QuizAnswerThree = string.Empty;

        CorrectAnswerOne = false;
        CorrectAnswerTwo = false;
        CorrectAnswerThree = false;

        //await Task.Delay(1000);
        QuizAnswer = string.Empty;

        #endregion

       // await Task.Delay(10000);
        //_quizManger.CurrentQuiz.GetRandomQuestion();
        CanFillBoxes = true;
    }

    private string _quizStatment;

    public string QuizStatment
    {
        get
        {
            return _quizStatment = _quizManger.CurrentQuiz.RandomQuestion.Statement;
        }
        set
        {
            SetProperty(ref _quizStatment, value);
        }
    }

    private string _quizAnswerOne;

    public string QuizAnswerOne
    {
        get { return _quizAnswerOne = _quizManger.CurrentQuiz.RandomQuestion.Answers[0]; }
        set
        {
            SetProperty(ref _quizAnswerOne, value);
        }
    }

    private string _quizAnswerTwo;

    public string QuizAnswerTwo
    {
        get { return _quizAnswerTwo = _quizManger.CurrentQuiz.RandomQuestion.Answers[1]; ; }
        set
        {
            SetProperty(ref _quizAnswerTwo, value);
        }
    }

    private string _quizAnswerThree;

    public string QuizAnswerThree
    {
        get { return _quizAnswerThree = _quizManger.CurrentQuiz.RandomQuestion.Answers[2]; ; }
        set
        {
            SetProperty(ref _quizAnswerThree, value);
        }
    }

    public int PlayersQuizAnswer { get; set; }

    private string _quizAnswer = String.Empty;

    public string QuizAnswer
    {
        get { return _quizAnswer; }
        set
        {
            SetProperty(ref _quizAnswer, value);
        }
    }
    void IsItCorrect()
    {
        

        if (CorrectAnswerOne == true)
        {
            PlayersQuizAnswer = 0;
            if (PlayersQuizAnswer == _quizManger.CurrentQuiz.RandomQuestion.CorrectAnswer)
            {
                QuizAnswer = "Correct";
                AmountRightAnswers = AmountRightAnswers + 1;
                CanNextQuestion = true;
                CanFillBoxes = false;
            }
            else
            {
                QuizAnswer = "Wrong";
                CanNextQuestion = true;
                CanFillBoxes = false;
            }
        }

        else if (CorrectAnswerTwo == true)
        {
            PlayersQuizAnswer = 1;
            if (PlayersQuizAnswer == _quizManger.CurrentQuiz.RandomQuestion.CorrectAnswer)
            {
                QuizAnswer = "Correct";
                AmountRightAnswers = AmountRightAnswers + 1;
                CanNextQuestion = true;
                CanFillBoxes = false;
            }
            else
            {
                QuizAnswer = "Wrong";
                CanNextQuestion = true;
                CanFillBoxes = false;
            }
        }

        else if (CorrectAnswerThree == true)
        {
            PlayersQuizAnswer = 2;
            if (PlayersQuizAnswer == _quizManger.CurrentQuiz.RandomQuestion.CorrectAnswer)
            {
                QuizAnswer = "Correct";
                AmountRightAnswers = AmountRightAnswers + 1;
                CanNextQuestion = true;
                CanFillBoxes = false;
            }
            else
            {
                QuizAnswer = "Wrong";
                CanNextQuestion = true;
                CanFillBoxes = false;
            }
        }

       
    }

    private bool _correctAnswerOne;

    public bool CorrectAnswerOne
    {
        get { return _correctAnswerOne; }
        set
        {
            SetProperty(ref _correctAnswerOne, value);
            IsItCorrect();
        }
    }

    private bool _correctAnswerTwo;

    public bool CorrectAnswerTwo
    {
        get { return _correctAnswerTwo; }
        set
        {
            SetProperty(ref _correctAnswerTwo, value);
            IsItCorrect();
        }
    }

    private bool _correctAnswerThree;

    public bool CorrectAnswerThree
    {
        get { return _correctAnswerThree; }
        set
        {
            SetProperty(ref _correctAnswerThree, value);
            IsItCorrect();
        }
    }

    //public int AmountRightAnswers { get; set; } = 0;


    private int _amountRightAnswers = 0;

    public int AmountRightAnswers
    {
        get { return _amountRightAnswers; }
        set
        {
            SetProperty(ref _amountRightAnswers, value);
        }
    }

    //public string AmountAnswers { get; set; } = "/10";


    public int AmountAnswersTotal { get; set; } = 0;

    //private int _amountAnswers;

    //public int AmountAnswers
    //{
    //    get
    //    {
    //        return _amountAnswers;
    //    }
    //    set
    //    {
    //        SetProperty(ref _amountAnswers, value);
    //    }
    //}

     private bool _canFillBoxes = true;

    public bool CanFillBoxes
    {
        get { return _canFillBoxes; }
        set { SetProperty(ref _canFillBoxes, value); }
    }

    private bool _canNextQuestion = false;

    public bool CanNextQuestion
    {
        get { return _canNextQuestion; }
        set { SetProperty(ref _canNextQuestion, value); }
    }
}