using System;
using System.Dynamic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Labb3_NET22.DataModels;
using Labb3_NET22.Managers;

namespace Labb3_NET22.ViewModel;

public class CreateQuizTitleViewModel : ObservableObject
{
    private readonly QuizModel _quizModel;
    private readonly QuizManger _quizManger;

    private readonly QuestionModel _questionModel;

    private readonly NavigationManager _navigationManager;

   public IRelayCommand createQuizCommand { get; }
    public CreateQuizTitleViewModel(QuizManger quizManger, NavigationManager navigationManager)
    {
        _quizManger = quizManger;
        _quizModel = quizManger.CurrentQuiz;
        _navigationManager = navigationManager;

        createQuizCommand = new RelayCommand(() => Create());
    }

    public void Create()
    {
        //_quizManger.CurrentQuiz = new QuizModel(QuizTitle);
        _navigationManager.CurrentViewModel = new CreateQuizViewModel(_quizManger, _navigationManager);
    }


    private string _quizTitle = String.Empty;

    public string QuizTitle
    {
        get { return _quizTitle; }
        set
        {
            SetProperty(ref _quizTitle, value);
        }
    }
}