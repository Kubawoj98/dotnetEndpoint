using dotNetEndpoint.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace dotNetEndpoint;

[Route("[controller]")]
public class Nullable : Controller
{
    [Route("init_nullable")]
    public string ConsoleWriteLine()
    {
        string test = "";
        var surveyRun = new SurveyRun();
        surveyRun.AddQuestion(QuestionType.YesNo, "Has your code ever thrown a NullReferenceException?");
        surveyRun.AddQuestion(new SurveyQuestion(QuestionType.Number, "How many times (to the nearest 100) has that happened?"));
        surveyRun.AddQuestion(QuestionType.Text, "What is your favorite color?");
        surveyRun.AddQuestion(QuestionType.Text, default);

        surveyRun.PerformSurvey(50);

        foreach (var participant in surveyRun.AllParticipants)
        {
            Console.WriteLine($"Participant: {participant.Id}:");
            test += $"Participant: {participant.Id}:";
            if (participant.AnsweredSurvey)
            {
                for (int i = 0; i < surveyRun.Questions.Count; i++)
                {
                    var answer = participant.Answer(i);
                    Console.WriteLine($"\t{surveyRun.GetQuestion(i).QuestionText} : {answer}");
                    test += $"\t{surveyRun.GetQuestion(i).QuestionText} : {answer}";
                }
            }
            else
            {
                Console.WriteLine("\tNo responses");
                test += "\tNo responses";
            }
        }
        RevDeBugAPI.Snapshot.RecordSnapshot("init_nullable");
        return test;
    }
}
