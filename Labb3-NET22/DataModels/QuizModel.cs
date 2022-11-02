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





    public QuestionModel RandomQuestion { get; set; }
    public List<QuestionModel> DeserializedQuiz {get; set; } = new List<QuestionModel>();




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
        var rand = new Random();

        RandomQuestion = DeserializedQuiz[rand.Next(DeserializedQuiz.Count)];

        return RandomQuestion;
    }



    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {

        _questions = _questions.Concat(new[] { new QuestionModel(statement, answers, correctAnswer) });

    }

    public void RemoveQuestion(int index)
    {
        DeserializedQuiz.RemoveAt(index);

        //throw new NotImplementedException("Question at requested index need to be removed here!");
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



    

}