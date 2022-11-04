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
    public List<QuestionModel> DeserializedQuiz {get; set; }



    public QuizModel NewQuiz { get; set; }
    public void AddTitle(string qTitle)
    {
        _title = qTitle.ToLower();
    }

    public QuizModel(string title)
    {
        _title = title.ToLower();
        _questions = new List<QuestionModel>();
    }

    public QuizModel()
    {
        _questions = new List<QuestionModel>();
        _defaultQuestions = new List<QuestionModel>();
        _title = Title;
    }

    public void ClearQuestions()
    {
        var temp = _questions.ToList();

        for (int i = 0; i < temp.Count; i++)
        {
            temp.RemoveAt(i);
        }

        _questions = temp;
    }

    public List<int> RandomNum { get; set; }
    public QuestionModel GetRandomQuestion()
    {
        
        var rand = new Random();
        var randNext = rand.Next(DeserializedQuiz.Count);


        //RandomNum.Add(randNext);
        RandomQuestion = DeserializedQuiz[randNext];

        return RandomQuestion;
    }



    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {

        _questions = _questions.Concat(new[] { new QuestionModel(statement, answers, correctAnswer) });

    }

    public void RemoveQuestion(int index)
    {
        var temp = DeserializedQuiz.ToList();
        temp.RemoveAt(index);
        DeserializedQuiz = temp;

        _questions = DeserializedQuiz.AsEnumerable();

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

        _defaultQuestions = _defaultQuestions.Concat(new[]
        {
            new QuestionModel(
                "Which of the following is not an international organisation?",
                new string[3] { "NATO", "FBI", "ASEAN" },
                1)
        });

        _defaultQuestions = _defaultQuestions.Concat(new[]
        {
            new QuestionModel(
                "Which of the following disorders is the fear of being alone?",
                new string[3] { "Agoraphobia", "Acrophobia", "Arachnophobia" },
                0)
        });

        _defaultQuestions = _defaultQuestions.Concat(new[]
        {
            new QuestionModel(
                "Which of the following is a song by the German heavy metal band “Scorpions”?",
                new string[3] { "Wind of Change", "Hey Jude", "Don’t Stop Me Now" },
                0)
        });

        _defaultQuestions = _defaultQuestions.Concat(new[]
        {
            new QuestionModel(
                "What is the speed of sound?",
                new string[3] { "120 km/h", "400 km/h", "1,200 km/h" },
                2)
        });

        _defaultQuestions = _defaultQuestions.Concat(new[]
        {
            new QuestionModel(
                "Which is the easiest way to tell the age of many trees?",
                new string[3] { "To measure the width of the tree", "To count the rings on the trunk", "To measure the height of the tree" },
                1)
        });

        _defaultQuestions = _defaultQuestions.Concat(new[]
        {
            new QuestionModel(
                "What do we call a newly hatched butterfly?",
                new string[3] { "A caterpillar", "A chrysalis", "A moth" },
                0)
        });

        _defaultQuestions = _defaultQuestions.Concat(new[]
        {
            new QuestionModel(
                "In total, how many novels were written by the Bronte sisters?",
                new string[3] { "4", "7", "5" },
                1)
        });

        _defaultQuestions = _defaultQuestions.Concat(new[]
        {
            new QuestionModel(
                "Which did Viking people use as money?",
                new string[3] { "Rune stones", "Wool", "Jewellery" },
                1)
        });
    }



    

}