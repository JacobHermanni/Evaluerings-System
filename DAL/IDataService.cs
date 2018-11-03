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

        Question CreateQuestion(int questionID, string description);

        Evaluation AddReport(int evaluation_id, string report);

        bool DeleteQuestion(int questionID);

        List<QuestionOption> GetQuestionOptions();
    
    }
}