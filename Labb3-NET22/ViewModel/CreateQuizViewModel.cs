using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Labb3_NET22.DataModels;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.Managers;

namespace Labb3_NET22.ViewModel;

public class CreateQuizViewModel : ObservableObject
{
    public ICommand SaveQuestion { get; }

    public ICommand NewQuestionCommand { get; }
    public ICommand CreateJson { get; }
    public ICommand ReturnToStartViewCommand { get; }

    private readonly QuizModel _quizModel;

    private readonly QuestionModel _questionModel;

    private readonly NavigationManager _navigationManager;
    public CreateQuizViewModel(QuizModel quizModel, NavigationManager navigationManager)
    {
        _quizModel = quizModel;

        _navigationManager = navigationManager;

        SaveQuestion = new RelayCommand(AddQ);

       //CreateJson = new RelayCommand(() => CreateJ());

       ReturnToStartViewCommand = new RelayCommand(() => ReturnToStartView());

       NewQuestionCommand = new RelayCommand(() => NewQuestion() );

    }

    public void NewQuestion()
    {
        CanSaveQuiz = false;
        CanCloseCreateQuiz = false;
        CanFillQuestionBoxes = true;

    }

    private string _q;

    public string Q
    {
        get { return _q; }
        set { _q = value; }
    }

    public async Task ReturnToStartView()
    {
        _quizModel.AddTitle(QuizTitle);
        await Task.Delay(5);
        _quizModel.Json();
        _navigationManager.CurrentViewModel = new StartViewModel(_quizModel, _navigationManager);


    }

  

    void AddQ() // save
    {
       

        var QuizAnswers = new string[] { QuizAnswerOne, QuizAnswerTwo, QuizAnswerThree };

        Correct();

        _quizModel.AddQuestion(QuizStatment, QuizCorrectAnswer, QuizAnswers);

        #region stringEmpty
        QuizStatment = string.Empty;

        QuizAnswerOne = string.Empty;
        QuizAnswerTwo = string.Empty;
        QuizAnswerThree = string.Empty;

        CorrectAnswerOne = false;
        CorrectAnswerTwo = false;
        CorrectAnswerThree = false;

        #endregion
        CanSaveQuiz = false;
        CanNewQuestion = true;
        CanCloseCreateQuiz = true;
        CantChangeTitle = false;
        CanFillQuestionBoxes = false;
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


    private string _quizTitle = String.Empty;

    public string QuizTitle
    {
        get { return _quizTitle; }
        set
        {
            SetProperty(ref _quizTitle, value);
            CheckAllBoxes();
        }
    }

    private string _quizStatment = String.Empty;

    public string QuizStatment
    {
        get { return _quizStatment; }
        set
        {
            SetProperty(ref _quizStatment, value);
            CheckAllBoxes();
        }
    }

    private string _quizAnswerOne = String.Empty;

    public string QuizAnswerOne
    {
        get { return _quizAnswerOne; } 
        set
        {
            SetProperty(ref _quizAnswerOne, value);
            CheckAllBoxes();
        }
    }

    private string _quizAnswerTwo = String.Empty;

    public string QuizAnswerTwo
    {
        get { return _quizAnswerTwo; }
        set
        {
            SetProperty(ref _quizAnswerTwo, value);
            CheckAllBoxes();
        }
    }

    private string _quizAnswerThree = String.Empty;

    public string QuizAnswerThree
    {
        get { return _quizAnswerThree; }
        set
        {
            SetProperty(ref _quizAnswerThree, value);
            CheckAllBoxes();
        }
    }



    public void CheckAllBoxes()
    {
        if (QuizAnswerOne != String.Empty)
        {
            if (QuizAnswerTwo != String.Empty )
            {
                if (QuizAnswerThree != String.Empty)
                {
                    if (QuizStatment != String.Empty)
                    {
                        if (QuizTitle != String.Empty)
                        {
                            if (CorrectAnswerOne == true || CorrectAnswerTwo == true || CorrectAnswerThree == true)
                            {
                                CanSaveQuiz = true;
                                CanNewQuestion = false;
                            }
                        }
                    }
                }
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
            CheckAllBoxes();
        }
    }

    private bool _correctAnswerTwo;

    public bool CorrectAnswerTwo
    {
        get { return _correctAnswerTwo; }
        set
        {
            SetProperty(ref _correctAnswerTwo, value);
            CheckAllBoxes();
        }
    }

    private bool _correctAnswerThree;

    public bool CorrectAnswerThree
    {
        get { return _correctAnswerThree; }
        set
        {
            SetProperty(ref _correctAnswerThree, value);
            CheckAllBoxes();
        }
    }

    private bool _canCloseCreateQuiz = false;

    public bool CanCloseCreateQuiz
    {
        get { return _canCloseCreateQuiz; }
        set { SetProperty(ref _canCloseCreateQuiz, value); }
    }

    private bool _canFillQuestionBoxes = true;

    public bool CanFillQuestionBoxes
    {
        get { return _canFillQuestionBoxes; }
        set { SetProperty(ref _canFillQuestionBoxes, value); }
    }

    private bool _canSaveQuiz = false;

    public bool CanSaveQuiz
    {
        get { return _canSaveQuiz; }
        set { SetProperty(ref _canSaveQuiz, value); }
    }

    private bool _canNewQuestion = false;

    public bool CanNewQuestion
    {
        get { return _canNewQuestion; }
        set { SetProperty(ref _canNewQuestion, value);  }
    }

    private bool _cantChangeTitle = true;

    public bool CantChangeTitle
    {
        get { return _cantChangeTitle; }
        set { SetProperty(ref _cantChangeTitle, value); }
    }

    public bool CanItClose { get; set; }
    void CheckCanClose()
    {

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
