using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Labb3_NET22.DataModels;
using CommunityToolkit.Mvvm.Input;

namespace Labb3_NET22.ViewModel;

public class CreateQuizViewModel : ObservableObject
{
    public ICommand UpdateCommand { get; }

    private readonly QuizModel _quizModel;

    private readonly QuestionModel _questionModel;
    public CreateQuizViewModel(QuizModel quizModel)
    {
        _quizModel = quizModel;

    }

    private string _quizTitle;

    public string QuizTitle
    {
        get { return _quizTitle; }
        set
        {
            _quizTitle = value;
            
    }


    
}
