using System.Collections.Generic;
using System.Net.Http.Headers;
using DAL.Models;

namespace DAL
{
    public interface IDataService
    {
        List<Course> GetCourses();

        List<Evaluation> GetEvaluations();

        List<Questionnaire> GetQuestionnaires();

        List<Question> GetQuestions();

        Question GetQuestion(int questionID);

        Question CreateQuestionInBank(int questionID, string description);

        Question CreateQuestionOnQuestionnaire(int questionnaireID, int questionID, string description);

        bool DeleteQuestion(int questionID);

    }
}