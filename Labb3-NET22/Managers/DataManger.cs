using Labb3_NET22.DataModels;

namespace Labb3_NET22.Managers;

public class DataManger
{
    private QuizModel _quizModel = new QuizModel();

    public QuizModel DataModel => _quizModel;

}