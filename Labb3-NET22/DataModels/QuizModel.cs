using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Labb3_NET22.DataModels;

public class QuizModel
{
    private readonly QuestionModel _questionModel;

    private readonly QuizModel _quizModel;

    private IEnumerable<QuestionModel> _questions;
    public IEnumerable<QuestionModel> Questions => _questions;

    private string _title = string.Empty;
    public string Title => _title;

    public async Task Json()
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Quiz.json");

        if (!File.Exists(path))
        {
            var json = JsonSerializer.Serialize(_questions, new JsonSerializerOptions() { WriteIndented = true });

         
            using StreamWriter sw = new StreamWriter(path);
            
            sw.WriteLine(json);
        }
    }



    public QuizModel()
    {
        _questions = new List<QuestionModel>();
        //_title = title;
    }

    public QuestionModel GetRandomQuestion()
    {
        //var db = new QuizModel();

        //var output = db.Questions
        //    .Where(p => p.Statement.Contains('a'))
        //    .Select(p => p);

        //foreach (var VARIABLE in output)
        //{
        //    VARIABLE.Statement.Contains('a');
        //}

        

        throw new NotImplementedException("A random Question needs to be returned here!");
    }

    public void SendQ()
    {
    }

    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {


        var nyfråga = new QuestionModel(statement, answers, correctAnswer);
        _questions = _questions.Concat(new[] { nyfråga });
       // Hej();



        //throw new NotImplementedException("Question need to be instantiated and added to list of questions here!");
    }

    public void RemoveQuestion(int index)
    {
        throw new NotImplementedException("Question at requested index need to be removed here!");
    }

    

}