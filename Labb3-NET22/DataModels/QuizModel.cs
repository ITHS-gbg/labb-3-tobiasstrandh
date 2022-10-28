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
        await Task.Run(() => {
            
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Title);

            if (!File.Exists(path))
            {
                var Qlist = _questions.ToList();

                var json = JsonSerializer.Serialize(Questions, new JsonSerializerOptions() { WriteIndented = true });


                using StreamWriter sw = new StreamWriter(path);


                sw.WriteLine(json);
                
            }

            else if (File.Exists(path))
            {


                var json = JsonSerializer.Serialize(_questions.Last(), new JsonSerializerOptions() { WriteIndented = true });

                //using StreamWriter sw = new StreamWriter(path);

                using StreamWriter sw = new StreamWriter(File.Open(path, System.IO.FileMode.Append));

                sw.WriteLine(json);


            }
        });

        
    }

    public async Task DownloadJson(string  qTitle)
    {
        qTitle += $".json";

        _title = qTitle;

        await Task.Run(() =>
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Title);

            if (File.Exists(path))
            {
                var text = string.Empty;
                string? line = string.Empty;


                using StreamReader sr = new StreamReader(path);

                while ((line = sr.ReadLine()) != null)
                {
                    text += line;
                }

                Quizquestions = JsonSerializer.Deserialize<List<QuestionModel>>(text)!;


            }
        });

        GetRandomQuestion();
    }

    public QuestionModel RandomQuestion { get; set; }
    public List<QuestionModel> Quizquestions { get; set; }

    public void AddTitle(string qTitle)
    {
        qTitle += $".json";

        _title = qTitle;
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
        //    .Where(p => p.Statement.r
        //    .Select(p => p);

        var rand = new Random();
        RandomQuestion = Quizquestions[rand.Next(Quizquestions.Count)];

        return RandomQuestion;

        //throw new NotImplementedException("A random Question needs to be returned here!");
    }

    public void SendQ()
    {
    }

    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {

        var nyfråga = new QuestionModel(statement, answers, correctAnswer);
        _questions = _questions.Concat(new[] { nyfråga });
        //Json();


        //throw new NotImplementedException("Question need to be instantiated and added to list of questions here!");
    }

    public void RemoveQuestion(int index)
    {
        throw new NotImplementedException("Question at requested index need to be removed here!");
    }

    

}