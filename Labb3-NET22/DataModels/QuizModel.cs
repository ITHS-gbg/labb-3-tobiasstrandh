using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb3_NET22.DataModels;

public class QuizModel
{
    public string ReverseMyText()
    {
        var output = string.Empty;

        for (int i = Title.Length - 1; i >= 0; i--)
        {
            output += Title[i];
        }

        return output;
    }

    private IEnumerable<QuestionModel> _questions;
    public IEnumerable<QuestionModel> Questions => _questions;

    private string _title = string.Empty;
    public string Title => _title;

    public QuizModel()
    {
        _questions = new List<QuestionModel>();
        //_title = title;
    }

    public QuestionModel GetRandomQuestion()
    {
        var db = new QuizModel();

        var output = db.Questions
            .Where(p => p.Statement.Contains("hej"))
            .Select(p => p);

        var Q = string.Empty;

        foreach (var VARIABLE in output)
        {
            VARIABLE.Statement = Q;
        }

        //throw new NotImplementedException("A random Question needs to be returned here!");
    }

     static QuestionModel SendQ()
    {
        var db = new QuizModel();

        var output = db.Questions
            .Where(p => p.Statement.Contains("hej"))
            .Select(p => p);

        return output;
    }

    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {


        var nyfråga = new QuestionModel(statement, answers, correctAnswer);
        _questions = _questions.Concat(new[] { nyfråga });

        //throw new NotImplementedException("Question need to be instantiated and added to list of questions here!");
    }

    public void RemoveQuestion(int index)
    {
        throw new NotImplementedException("Question at requested index need to be removed here!");
    }

    

}