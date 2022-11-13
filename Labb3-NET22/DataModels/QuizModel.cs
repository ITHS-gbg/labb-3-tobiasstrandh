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
   

    private IEnumerable<QuestionModel> _questions;

    [JsonInclude]
    public IEnumerable<QuestionModel> Questions
    {
        get { return _questions; }

        init => _questions = value;
    }


    private string _title = string.Empty;
    public string Title => _title;



    public QuizModel()
    {
        _questions = new List<QuestionModel>();

    }
    [JsonConstructor]
    public QuizModel(string title)
    {
        _title = title.ToLower();
        _questions = new List<QuestionModel>();
    }

    

    private List<int> NumberList { get; set; } = new List<int>();
    private QuestionModel Question { get; set; }
    public QuestionModel GetRandomQuestion()
    {
        var random = new Random();
        var randNext = random.Next(0, Questions.Count());
       

        if (!NumberList.Contains(randNext))
        {
            Question = Questions.ElementAt(randNext);
            NumberList.Add(randNext);
        }

        else
        {
            GetRandomQuestion();
        }

        return Question;
    }



    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {

        _questions = _questions.Append(new QuestionModel(statement, answers, correctAnswer));

    }

    public void EditQuestion(int index, string statement, int correctAnswer, params string[] answers)
    {


        RemoveQuestion(index);

        var listOne = _questions.ToList();

        
        List<QuestionModel> listTwo = new List<QuestionModel>();

        for (int i = 0; i < listOne.Count; i++)
        {
            if (i == index)
            {
                listTwo.Add(new QuestionModel(statement, answers, correctAnswer));
                if (i != listOne.Count)
                {
                    listTwo.Add(listOne[i]);
                }
            }

            else
            {
                listTwo.Add(listOne[i]);
            }
        }

        _questions = listTwo;
    }

    public void RemoveQuestion(int index)
    {
        var list = _questions.ToList();
        list.RemoveAt(index);
        _questions = list;

    }
    public void PopulateDefaultQuiz()
    {
        _questions = _questions.Append(
            new QuestionModel(
                "In 1768, Captain James Cook set out to explore which ocean?",
                new string[3] { "Pacific Ocean", "Atlantic Ocean", "Indian Ocean" },
                0)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "What is actually electricity?",
                new string[3] { "A flow of atoms", "A flow of air", "A flow of electrons" },
                2)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "Which of the following is not an international organisation?",
                new string[3] { "NATO", "FBI", "ASEAN" },
                1)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "Which of the following disorders is the fear of being alone?",
                new string[3] { "Agoraphobia", "Acrophobia", "Arachnophobia" },
                0)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "Which of the following is a song by the German heavy metal band “Scorpions”?",
                new string[3] { "Wind of Change", "Hey Jude", "Don’t Stop Me Now" },
                0)
        );


        _questions = _questions.Append(
            new QuestionModel(
                "What is the speed of sound?",
                new string[3] { "120 km/h", "400 km/h", "1,200 km/h" },
                2)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "Which is the easiest way to tell the age of many trees?",
                new string[3] { "To measure the width of the tree", "To count the rings on the trunk", "To measure the height of the tree" },
                1)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "What do we call a newly hatched butterfly?",
                new string[3] { "A caterpillar", "A chrysalis", "A moth" },
                0)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "In total, how many novels were written by the Bronte sisters?",
                new string[3] { "4", "7", "5" },
                1)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "Which did Viking people use as money?",
                new string[3] { "Rune stones", "Wool", "Jewellery" },
                2)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "What was the first country to use tanks in combat during World War I?",
                new string[3] { "France", "Britain", "Germany" },
                1)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "What is the main component of the sun?",
                new string[3] { "Liquid lava", "Molten iron", "Gas" },
                2)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "Goulash is a type of beef soup in which country?",
                new string[3] { "Hungary", "Czech Republic", "Slovakia" },
                0)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "Which two months are named after Emperors of the Roman Empire?",
                new string[3] { "July and August", "May and June", "March and April" },
                0)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "Which of the following animals can run the fastest?",
                new string[3] { "Tiger", "Cheetah", "Leopard" },
                1)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "Where did the powers of Spiderman come from?",
                new string[3] { "He went through a scientific experiment", "He woke up with them after a dream", "He was bitten by a radioactive spider" },
                2)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "What is the most points that a player can score with a single throw in darts?",
                new string[3] { "20", "40", "60" },
                2)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "In the United States, football is called soccer. So what is American football called in the United Kingdom?",
                new string[3] { "American football", "Rugby", "Combball" },
                0)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "Which of the following actors was the first one to play James Bond?",
                new string[3] { "Sean Connery", "Roger Moore", "Timothy Dalton" },
                0)
        );

        _questions = _questions.Append(
            new QuestionModel(
                "Which of the following songs was the top-selling hit in 2019?",
                new string[3] { "Old Town Road", "Someone You Loved", "Bad Guy" },
                1)
        );


    }


}