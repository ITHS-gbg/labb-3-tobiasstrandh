using System;
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

    public ICommand NextQuestion { get; }

    public QuizViewModel (QuizModel quizModel, NavigationManager navigationManager)
    {
       
        _quizModel = quizModel;

        _navigationManager = navigationManager;

        NextQuestion = new RelayCommand(() => Correct());
    }

    private string _quizStatment;

    public string QuizStatment
    {
        get
        {
            return _quizStatment = _quizModel.RandomQuestion.Statement;
        }
        set
        {
            SetProperty(ref _quizStatment, value);
        }
    }

    private string _quizAnswerOne;

    public string QuizAnswerOne
    {
        get { return _quizAnswerOne = _quizModel.RandomQuestion.Answers[0]; }
        set
        {
            SetProperty(ref _quizAnswerOne, value);
        }
    }

    private string _quizAnswerTwo;

    public string QuizAnswerTwo
    {
        get { return _quizAnswerTwo = _quizModel.RandomQuestion.Answers[1]; }
        set
        {
            SetProperty(ref _quizAnswerTwo, value);
        }
    }

    private string _quizAnswerThree;

    public string QuizAnswerThree
    {
        get { return _quizAnswerThree = _quizModel.RandomQuestion.Answers[2]; }
        set
        {
            SetProperty(ref _quizAnswerThree, value);
        }
    }

    public int PlayersQuizAnswer { get; set; }

    private string _quizAnswer = String.Empty;

    public string QuizAnswer
    {
        get { return _quizAnswer;} 
        set
        {
            SetProperty(ref _quizAnswer, value);
        }
    }
    void Correct()
    {
        if (CorrectAnswerOne == true)
        {
            PlayersQuizAnswer = 0;
            if (PlayersQuizAnswer == _quizModel.RandomQuestion.CorrectAnswer)
            {
                QuizAnswer = "Correct";
                AmountRightAnswers++;
            }
            else
            {
                QuizAnswer = "Wrong";
            }
        }

        else if (CorrectAnswerTwo == true)
        {
            PlayersQuizAnswer = 1;
            if (PlayersQuizAnswer == _quizModel.RandomQuestion.CorrectAnswer)
            {
                QuizAnswer = "Correct";
                AmountRightAnswers++;
            }
            else
            {
                QuizAnswer = "Wrong";
            }
        }

        else if (CorrectAnswerThree == true)
        {
            PlayersQuizAnswer = 2;
            if (PlayersQuizAnswer == _quizModel.RandomQuestion.CorrectAnswer)
            {
                QuizAnswer = "Correct";
                AmountRightAnswers++;
            }
            else
            {
                QuizAnswer = "Wrong";
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

    private string _amountAnswers;

    public string AmountAnswers
    {
        get
        {
            return _amountAnswers = AmountRightAnswers.ToString();
        }
        set
        {
            SetProperty(ref _amountAnswers, value);
        }
    }
}