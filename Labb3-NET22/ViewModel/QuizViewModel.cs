using CommunityToolkit.Mvvm.ComponentModel;
using Labb3_NET22.DataModels;

namespace Labb3_NET22.ViewModel;

public class QuizViewModel : ObservableObject
{
    private readonly QuizModel _quizModel;
    public QuizViewModel (QuizModel quizModel)
    {
        //Sätter fältet _demoModel till den inskickade instansen av DemoModel så den blir åtkomlig
        _quizModel = quizModel;

        //Tilldelar en instans av DemoCommand till propertyn UpdateCommand
        //UpdateCommand = new RelayCommand(() => MyTextReversed = demoModel.ReverseMyText(), () => true);
    }
}