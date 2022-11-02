using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media;
using Labb3_NET22.DataModels;

namespace Labb3_NET22.Managers;

public class QuizManger
{
    private QuizModel _quizModel = new QuizModel();

    public QuizModel CurrentQuiz => _quizModel;



    public async Task JsonDM()
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{CurrentQuiz.Title}.json");
        var pathDefaultQuiz = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"tobbesquiz.json");

        if (!File.Exists(pathDefaultQuiz))
        {
            
            var json = await Task.Run((() => JsonSerializer.Serialize(CurrentQuiz.DefaultQuestions, new JsonSerializerOptions() { WriteIndented = true })));


            await using StreamWriter sw = new StreamWriter(pathDefaultQuiz);


            sw.WriteLine(json);

            
        }

        
           

        if (!File.Exists(path) && CurrentQuiz.Title != string.Empty)
        {
            var json = await Task.Run((() => JsonSerializer.Serialize(CurrentQuiz.Questions, new JsonSerializerOptions() { WriteIndented = true })));


            await using StreamWriter sw = new StreamWriter(path);


            sw.WriteLine(json);

        }
        
        
    }


    public async Task<List<string>> JsonTitleList()
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        string[] file = Directory.GetFiles(path, "*.json");


        for (int i = 0; i < file.Length; i++)
        {
            file[i] = Path.GetFileNameWithoutExtension(file[i]);
        }

        return new List<string>(file);

    }

    public async Task DownloadJson() //string title
    {

        await Task.Run(() =>
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{CurrentQuiz.Title}.json");


            if (File.Exists(path))
            {
                var text = string.Empty;
                string? line = string.Empty;


                using StreamReader sr = new StreamReader(path);

                while ((line = sr.ReadLine()) != null)
                {
                    text += line;
                }

                CurrentQuiz.DeserializedQuiz = JsonSerializer.Deserialize<List<QuestionModel>>(text)!; 
                


            }
        });


    }


    

}