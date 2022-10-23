using System.Collections.Generic;
using System.Threading;

namespace Labb3_NET22.DataModels;

public class QuestionModel
{
    public string Statement { get; }
    public string[] Answers { get; }
    public int CorrectAnswer { get; }

}
