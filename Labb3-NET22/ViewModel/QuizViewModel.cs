using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
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

        RandomQuestion();

        NextQuestion = new RelayCommand(() => NextQ());
    }

    public async Task NextQ()
    {
        
        
            AmountAnswersTotal++;


        if (PlayersQuizAnswer == CorrrectAnswer)
        {
            AmountRightAnswers++;
        }

        var amountQuestions = _quizManger.CurrentQuiz.Questions.ToList();

        if (AmountAnswersTotal > amountQuestions.Count)
        {

            _navigationManager.CurrentViewModel = new StartViewModel(_quizManger, _navigationManager);
            
        }

        if (AmountAnswersTotal == amountQuestions.Count)
        {
            ButtonName = "Done with Quiz";
            CanNextQuestion = true;

            QuizStatment = "Press button to go back to start";

            QuizAnswerOne = string.Empty;
            QuizAnswerTwo = string.Empty;
            QuizAnswerThree = string.Empty;

            CorrectAnswerOne = false;
            CorrectAnswerTwo = false;
            CorrectAnswerThree = false;



            //_navigationManager.CurrentViewModel = new StartViewModel(_quizManger, _navigationManager);
        }






        //IsItCorrect();
        //CanFillBoxes = false;



        else if (AmountAnswersTotal < amountQuestions.Count)
        {
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

            CanNextQuestion = false;


            RandomQuestion();
        }
    }


    public async Task RandomQuestion()
    {
       

        var randomQuestion = _quizManger.CurrentQuiz.GetRandomQuestion();
           
        QuizStatment = randomQuestion.Statement;

        QuizAnswerOne = randomQuestion.Answers[0];
        QuizAnswerTwo = randomQuestion.Answers[1];
        QuizAnswerThree = randomQuestion.Answers[2];

        CorrrectAnswer = randomQuestion.CorrectAnswer;
        
    }

    public int CorrrectAnswer { get; set; }

    private string _quizStatment;

    public string QuizStatment
    {
        get
        {

            return _quizStatment;
        }
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

    private string _quizAnswerTwo;

    public string QuizAnswerTwo
    {
        get { return _quizAnswerTwo;  }
        set
        {
            SetProperty(ref _quizAnswerTwo, value);
        }
    }

    private string _quizAnswerThree;

    public string QuizAnswerThree
    {
        get { return _quizAnswerThree;  }
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
            if (PlayersQuizAnswer == CorrrectAnswer)
            {
                QuizAnswer = "Correct";
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
            if (PlayersQuizAnswer == CorrrectAnswer)
            {
                QuizAnswer = "Correct";
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
            if (PlayersQuizAnswer == CorrrectAnswer)
            {
                QuizAnswer = "Correct";
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


    

    private int _amountAnswersTotal;

    public int AmountAnswersTotal
    {
        get { return _amountAnswersTotal; }
        set { SetProperty(ref _amountAnswersTotal, value);  }
    }

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

    private string _buttonName = "Next Question";

    public string ButtonName
    {
        get { return _buttonName; }
        set { SetProperty(ref _buttonName, value);  }
    }

}