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

    public EditViewModel(QuizManger quizManger, NavigationManager navigationManager)
    {
        _quizManger = quizManger;
        _navigationManager = navigationManager;
        _quiz = _quizManger.CurrentQuiz;
        LoadListViewM();

        Testa = new RelayCommand(() => haha());
        Remove = new RelayCommand(() => _quiz.RemoveQuestion(num));
    }

    //public QuestionModel SelectedQuestion { get; set; } = new QuestionModel();
    public QuestionModel MyQuestion { get; set; }

    public ICommand Testa { get; } //set?

    public ICommand Remove { get; } //set?
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

        }
    }

    public async Task SetList()
    {
        _quizManger.CurrentQuiz.AddTitle(QuizTitle);
        await _quizManger.DownloadJson();
        //await Task.Run( (() => QList = _quiz.DeserializedQuiz ));
        QList = _quiz.DeserializedQuiz;
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
        num = Convert.ToInt32(QuestionIndex);

        if (num >= 0)
        {
            QuestionStatment = QList.ElementAt(num).Statement;

            QuestionAnswerOne = QList.ElementAt(num).Answers[0];
            QuestionAnswerTwo = QList.ElementAt(num).Answers[1];
            QuestionAnswerThree = QList.ElementAt(num).Answers[2];


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

    private string __questionIndex;

    public string QuestionIndex
    {
        get { return __questionIndex; }
        set { SetProperty(ref __questionIndex, value); }
    }
}