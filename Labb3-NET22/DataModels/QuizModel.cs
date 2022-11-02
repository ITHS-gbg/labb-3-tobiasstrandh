using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    private IEnumerable<QuestionModel> _defaultQuestions;
    public IEnumerable<QuestionModel> DefaultQuestions => _defaultQuestions;

    private string _title = string.Empty;
    public string Title => _title;




    //public async Task DownloadJson(string qTitle)
    //{
    //    qTitle += $".json";

    //    _title = qTitle.ToLower();

    //    await Task.Run(() =>
    //    {
    //        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Title);

    //        if (File.Exists(path))
    //        {
    //            var text = string.Empty;
    //            string? line = string.Empty;


    //            using StreamReader sr = new StreamReader(path);

    //            while ((line = sr.ReadLine()) != null)
    //            {
    //                text += line;
    //            }

    //            Quizquestions = JsonSerializer.Deserialize<List<QuestionModel>>(text)!;


    //        }
    //    });


    //}

    public QuestionModel RandomQuestion { get; set; }
    public List<QuestionModel> DeserializedQuiz {get; set; }




    public void AddTitle(string qTitle)
    {
        _title = qTitle.ToLower();
    }

    public QuizModel()
    {
        _questions = new List<QuestionModel>();
        _defaultQuestions = new List<QuestionModel>();

    }

    

    public QuestionModel GetRandomQuestion()
    {
        //var workItemsToBeUpdated = DeserializedQuiz.Count();

        //var output = db.DeserializedQuiz
        //    .Last(p => p.Statement)
        //    .Select(p => p);

        
        ////var rNext = rand.Next(workItemsToBeUpdated);
        //RandomQuestion = DeserializedQuiz[rand.Next(workItemsToBeUpdated)];

        var rand = new Random();
        //IEnumerable<QuestionModel> result = DeserializedQuiz.OrderBy(x => rand.Next()).Take(1);
        RandomQuestion = DeserializedQuiz[rand.Next(DeserializedQuiz.Count)];


        //DeserializedQuiz.OrderBy(x => rand.Next()).Take(1);

        return RandomQuestion;

        throw new NotImplementedException("A random Question needs to be returned here!");
    }



    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {

        //var nyfråga = new QuestionModel(statement, answers, correctAnswer);
        _questions = _questions.Concat(new[] { new QuestionModel(statement, answers, correctAnswer) });



        //throw new NotImplementedException("Question need to be instantiated and added to list of questions here!");
    }

    public void RemoveQuestion(int index)
    {
        throw new NotImplementedException("Question at requested index need to be removed here!");
    }

    public void PopulateDefaultQuiz()
    {
        _defaultQuestions = _defaultQuestions.Concat(new[]
        {
            new QuestionModel(
                "In 1768, Captain James Cook set out to explore which ocean?",
                new string[3] { "Pacific Ocean", "Atlantic Ocean", "Indian Ocean" },
                0)
        });

        _defaultQuestions = _defaultQuestions.Concat(new[]
        {
            new QuestionModel(
                "What is actually electricity?",
                new string[3] { "A flow of atoms", "A flow of air", "A flow of electrons" },
                2)
        });


    }

    //public async Task DefaultQuizJson()
    //{
    //    await Task.Run(() =>
    //    {

    //        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
    //            "tobbesquiz.json");

    //        if (!File.Exists(path))
    //        {


    //            var json = JsonSerializer.Serialize(DefaultQuestions,
    //                new JsonSerializerOptions() { WriteIndented = true });


    //            using StreamWriter sw = new StreamWriter(path);


    //            sw.WriteLine(json);

    //        }

    //    });

    //}



    

}