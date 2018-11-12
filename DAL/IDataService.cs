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

        List<Question> GetQuestionsFromQuestionBank(int questionnaireID);

        Evaluation AddReport(int evaluation_id, string report);

        bool DeleteQuestion(int questionID);

        List<Answer> GetAnswers();

        List<Answer> GetAnswersFromQuestionnaire(int questionnaireID);

        void CreateAnswer(int question_id, int questionnaire_id, int answer);
    }
}