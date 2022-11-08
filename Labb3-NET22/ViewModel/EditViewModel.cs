using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.DataModels;
using Labb3_NET22.Managers;

namespace Labb3_NET22.ViewModel;

public class EditViewModel : ObservableObject
{
    private readonly NavigationManager _navigationManager;
    private readonly QuizModel _quiz;
    private readonly QuizManger _quizManger;
    private readonly QuestionModel _question;

    public EditViewModel(QuizManger quizManger, NavigationManager navigationManager)
    {
        _quizManger = quizManger;
        _navigationManager = navigationManager;
        _quiz = _quizManger.CurrentQuiz;
        LoadListView();

        
        Remove = new RelayCommand(() => RemoveQuestion());
        SaveEdit = new RelayCommand(() => Save());
        AddNewQuestionCommand = new RelayCommand(() => AddNewQuestion());
    }

    public async Task Save()
    {
        var QuizAnswers = new string[] { QuestionAnswerOne, QuestionAnswerTwo, QuestionAnswerThree };
       
        _quiz.RemoveQuestion(QuestionIndex);
        _quiz.AddQuestion(QuestionStatment, QuestionCorrectAnswer, QuizAnswers);
        await _quizManger.JsonSave();
    }
    public async Task RemoveQuestion()
    {
        
        _quiz.RemoveQuestion(QuestionIndex);
        await _quizManger.JsonSave();

        QuestionStatment = string.Empty;

        QuestionAnswerOne = string.Empty;
        QuestionAnswerTwo = string.Empty;
        QuestionAnswerThree = string.Empty;

        CorrectAnswerOne = false;
        CorrectAnswerTwo = false;
        CorrectAnswerThree = false;

        SetList();
    }

    
   

    public ICommand FillInBoxesCommand { get; } //set?

    public ICommand Remove { get; } //set?

    public ICommand SaveEdit { get; } //set?

    public ICommand AddNewQuestionCommand { get; } //set?
    public async Task LoadListView()
    {
        FileTitles = await _quizManger.JsonTitleList();
       
    }

    private List<string> _fileTitles;

    public List<string> FileTitles
    {
        get { return _fileTitles; }
        set
        {
            SetProperty(ref _fileTitles, value);
        }
    }

    private string _quizTitle;

    public string QuizTitle
    {
        get { return _quizTitle; }
        set
        {
            SetProperty(ref _quizTitle, value);
            SetList();
            //FillInBoxes();
            CanAddNewQuestion = true;

        }
    }

    public async Task SetList()
    {
        _quizManger.CurrentQuiz.AddTitle(QuizTitle);
        await _quizManger.DownloadJson();
       
        QuestionList = _quiz.DeserializedQuiz;
    }

    public async Task AddNewQuestion()
    {
        Correct();

        var QuizAnswers = new string[] { QuestionAnswerOne, QuestionAnswerTwo, QuestionAnswerThree };

        await _quizManger.CurrentQuiz.AddInEdit();

        await Task.Run((() => _quizManger.CurrentQuiz.AddQuestion(QuestionStatment, QuestionCorrectAnswer, QuizAnswers)));

        await _quizManger.JsonSave();
        
        QuestionStatment = string.Empty;

        QuestionAnswerOne = string.Empty;
        QuestionAnswerTwo = string.Empty;
        QuestionAnswerThree = string.Empty;

        CorrectAnswerOne = false;
        CorrectAnswerTwo = false;
        CorrectAnswerThree = false;

        SetList();

    }

    public void Correct()
    { 
       if (CorrectAnswerOne == true)
       {
           QuestionCorrectAnswer = 0;
       }

       else if (CorrectAnswerTwo == true)
       {
           QuestionCorrectAnswer = 1;
       }

       else if (CorrectAnswerThree == true)
       {
           QuestionCorrectAnswer = 2;
       }
    }

    private List<QuestionModel> _questionList;

    public List<QuestionModel> QuestionList
    {
        get { return _questionList; }
        set
        {
            SetProperty(ref _questionList, value);
        }
    }

    public void FillInBoxes()
    {
        if (QuestionIndex >= 0)
        {
            QuestionStatment = QuestionList.ElementAt(QuestionIndex).Statement;

            QuestionAnswerOne = QuestionList.ElementAt(QuestionIndex).Answers[0];
            QuestionAnswerTwo = QuestionList.ElementAt(QuestionIndex).Answers[1];
            QuestionAnswerThree = QuestionList.ElementAt(QuestionIndex).Answers[2];

            QuestionCorrectAnswer = QuestionList.ElementAt(QuestionIndex).CorrectAnswer;

            if (QuestionCorrectAnswer == 0)
            {
                CorrectAnswerOne = true;
            }

            else if (QuestionCorrectAnswer == 1)
            {
                CorrectAnswerTwo = true;
            }

            else if (QuestionCorrectAnswer == 2)
            {
                CorrectAnswerThree = true;
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
            if (CorrectAnswerOne.Equals(true))
            {
                CorrectAnswerTwo = false;
                CorrectAnswerThree = false;
            }
        }
    }

    private bool _correctAnswerTwo;

    public bool CorrectAnswerTwo
    {
        get { return _correctAnswerTwo; }
        set
        {
            SetProperty(ref _correctAnswerTwo, value);
            if (CorrectAnswerTwo.Equals(true))
            {
                CorrectAnswerThree = false;
                CorrectAnswerOne = false;
            }
        }
    }

    private bool _correctAnswerThree;

    public bool CorrectAnswerThree
    {
        get { return _correctAnswerThree; }
        set
        {
            SetProperty(ref _correctAnswerThree, value);
            if (CorrectAnswerThree.Equals(true))
            {
                CorrectAnswerTwo = false;
                CorrectAnswerOne = false;
                
            }

        }
    }

    private string _questionStatment;

    public string QuestionStatment
    {
        get { return _questionStatment; }
        set
        {
            SetProperty(ref _questionStatment, value);
        }
    }

    private string _questionAnswerOne = String.Empty;

    public string QuestionAnswerOne
    {
        get { return _questionAnswerOne; }
        set
        {
            SetProperty(ref _questionAnswerOne, value);
            
        }
    }

    private string _questionAnswerTwo = String.Empty;

    public string QuestionAnswerTwo
    {
        get { return _questionAnswerTwo; }
        set
        {
            SetProperty(ref _questionAnswerTwo, value);
            
        }
    }

    private string _questionAnswerThree = String.Empty;

    public string QuestionAnswerThree
    {
        get { return _questionAnswerThree; }
        set
        {
            SetProperty(ref _questionAnswerThree, value);
        }
    }

   

    private int _questionCorrectAnswer;

    public int QuestionCorrectAnswer
    {
        get { return _questionCorrectAnswer; }
        set
        {
            SetProperty(ref _questionCorrectAnswer, value);
        }
    }

    public void CheckQuestionCorrectAnswer()
    {
        if (QuestionCorrectAnswer == 0 || QuestionCorrectAnswer == 1 || QuestionCorrectAnswer == 2)
        {
            CanSaveEdit = true;
        }

        else
        {
            CanSaveEdit = false;
        }
    }

    private bool _canSaveEdit;

    public bool CanSaveEdit
    {
        get { return _canSaveEdit; }
        set { SetProperty(ref _canSaveEdit, value); }
    }

    private bool _canAddNewQuestion = false;

    public bool CanAddNewQuestion
    {
        get { return _canAddNewQuestion; }
        set { SetProperty(ref _canAddNewQuestion, value); }
    }

    private int _questionIndex;

    public int QuestionIndex
    {
        get { return _questionIndex; }
        set
        {
            SetProperty(ref _questionIndex, value);
            FillInBoxes();
        }
    }
}