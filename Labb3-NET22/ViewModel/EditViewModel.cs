using System.Collections.Generic;
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
    private readonly QuizModel _quizModel;
    private readonly QuizManger _quizManger;

    public EditViewModel(QuizManger quizManger, NavigationManager navigationManager)
    {
        _quizManger = quizManger;
        _navigationManager = navigationManager;
        LoadListViewM();

    }

    //public QuestionModel SelectedQuestion { get; set; } = new QuestionModel();
    public QuizManger MyQuestion { get; set; } = new QuizManger();

    public ICommand RemoveQuestionCommand { get; } //set?

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

    private List<QuestionModel> _qList;

    public List<QuestionModel> QList
    {
        get { return _qList; }
        set
        {
            SetProperty(ref _qList, value);
        }
    }

    private string _quizTitle;

    public string QuizTitle
    {
        get { return _quizTitle; }
        set
        {
            SetProperty(ref _quizTitle, value);
            _quizManger.CurrentQuiz.AddTitle(QuizTitle);
            _quizManger.DownloadJson();
            QList = _quizManger.CurrentQuiz.DeserializedQuiz;
        }
    }
}