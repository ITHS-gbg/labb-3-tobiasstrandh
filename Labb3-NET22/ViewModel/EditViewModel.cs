using System;
using System.Collections.Generic;
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
        LoadListViewM();

        Testa = new RelayCommand(() => haha());
        Remove = new RelayCommand(() => Rem());
        SaveEdit = new RelayCommand(() => Save());
        AddNewQuestionCommand = new RelayCommand(() => AddNewQuestion());
    }

    public async Task Save()
    {
        var QuizAnswers = new string[] { QuestionAnswerOne, QuestionAnswerTwo, QuestionAnswerThree };
        num = Convert.ToInt32(QuestionIndex);
        _quiz.RemoveQuestion(num);
        _quiz.AddQuestion(QuestionStatment, QuestionCorrectAnswer, QuizAnswers);
        await _quizManger.JsonDM();
    }
    public async Task Rem()
    {
        num = Convert.ToInt32(QuestionIndex); 
        _quiz.RemoveQuestion(num);
        await _quizManger.JsonDM();
    }

    //public QuestionModel SelectedQuestion { get; set; } = new QuestionModel();
    public QuestionModel MyQuestion { get; set; }

    public ICommand Testa { get; } //set?

    public ICommand Remove { get; } //set?

    public ICommand SaveEdit { get; } //set?

    public ICommand AddNewQuestionCommand { get; } //set?
    public async Task LoadListViewM()
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
            CanAddNewQuestion = true;

        }
    }

    public async Task SetList()
    {
        _quizManger.CurrentQuiz.AddTitle(QuizTitle);
        await _quizManger.DownloadJson();
       
        //await Task.Run( (() => QList = _quiz.DeserializedQuiz ));
        QList = _quiz.DeserializedQuiz;
    }

    public async Task AddNewQuestion()
    {
        var QuizAnswers = new string[] { QuestionAnswerOne, QuestionAnswerTwo, QuestionAnswerThree };

        await _quizManger.CurrentQuiz.AddInEdit();

        await Task.Run((() => _quizManger.CurrentQuiz.AddQuestion(QuestionStatment, QuestionCorrectAnswer, QuizAnswers)));

        await _quizManger.JsonDM();
        
        QuestionStatment = string.Empty;

        QuestionAnswerOne = string.Empty;
        QuestionAnswerTwo = string.Empty;
        QuestionAnswerThree = string.Empty;

    }

   

    private List<QuestionModel> _qList;

    public List<QuestionModel> QList
    {
        get { return _qList; }
        set
        {
            SetProperty(ref _qList, value);
        }
    }

    public int num { get; set; }
    public void haha()
    {
        CanAddNewQuestion = false;

        num = Convert.ToInt32(QuestionIndex);

        if (num >= 0)
        {
            QuestionStatment = QList.ElementAt(num).Statement;

            QuestionAnswerOne = QList.ElementAt(num).Answers[0];
            QuestionAnswerTwo = QList.ElementAt(num).Answers[1];
            QuestionAnswerThree = QList.ElementAt(num).Answers[2];

            QuestionCorrectAnswer = QList.ElementAt(num).CorrectAnswer;

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
            CheckQuestionCorrectAnswer();
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

    private string _questionIndex;

    public string QuestionIndex
    {
        get { return _questionIndex; }
        set { SetProperty(ref _questionIndex, value); }
    }
}