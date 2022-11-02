using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.DataModels;
using Labb3_NET22.Managers;

namespace Labb3_NET22.ViewModel;

public class ChooseQuizViewModel : ObservableObject
{
    private readonly QuizModel _quizModel;
    private readonly NavigationManager _navigationManager;
    private readonly QuizManger _quizManger;

    public ICommand ReturnToStartViewCommand { get; }
    public ICommand GoToQuizViewCommand { get; }
    public ICommand LoadListView { get; }

    public ICommand SaveTitleCommand { get; }
    public ChooseQuizViewModel(QuizManger quizManger, NavigationManager navigationManager)
    {
        
        
        _navigationManager = navigationManager;
        _quizManger = quizManger;
        LoadListViewM();


        //Lista();

        ReturnToStartViewCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new StartViewModel(_quizManger, _navigationManager));

        LoadListView = new RelayCommand(async () => { FileTitles = await _quizManger.JsonTitleList(); });

        GoToQuizViewCommand = new RelayCommand(() => GoToQuizView());

    }

    public async Task GoToQuizView()
    {
        
        if (QuizTitle == string.Empty)
        {
            QuizTitle = "TobbesQuiz";
        }

        _quizManger.CurrentQuiz.AddTitle(QuizTitle);
        await _quizManger.DownloadJson();
        await Task.Delay(300);
        

               

        _quizManger.CurrentQuiz.GetRandomQuestion();
        await Task.Delay(300);
        _navigationManager.CurrentViewModel = new QuizViewModel(_quizManger, _navigationManager);
    }

    public async Task LoadListViewM()
    {
        FileTitles = await _quizManger.JsonTitleList();
       
    }

    public QuizManger MyFiles { get; set; } = new QuizManger();

    //public void Lista()
    //{
    //    foreach (var VARIABLE in _quizManger.Files)
    //    {
    //        Path.GetFileName(VARIABLE);
    //    }

    //    //for (int i = 0; i < _quizManger.Files.Length; i++)
    //    //{
    //    //    _quizManger.Files[i] = FileTitles[i];

    //    //}
    //}

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
        }
    }

  


    void CheckTitleBox()
    {
        if (QuizTitle == "" || QuizTitle == " ")
        {
            CheckTileBoxSatus = false;
        }
    }

    private bool _checkTitleBoxStaus = true;

    public bool CheckTileBoxSatus
    {
        get { return _checkTitleBoxStaus; }
        set
        {
            SetProperty(ref _checkTitleBoxStaus, value);
            CheckTitleBox();
        }
    }
}