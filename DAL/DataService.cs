using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{

    public class DataService : IDataService
    {
        public List<Course> GetCourses()
        {
            using (var db = new EvalContext())
            {
                return db.Course
                    .OrderBy(x => x.course_id)
                    .ToList();
            }
        }

        public List<Evaluation> GetEvaluations()
        {
            using (var db = new EvalContext())
            {
                return db.Evaluation
                    .OrderBy(x => x.evaluation_id)
                    .ToList();
            }
        }

        public List<Questionnaire> GetQuestionnaires()
        {
            using (var db = new EvalContext())
            {
                return db.Questionnaire
                    .OrderBy(x => x.questionnaire_id)
                    .ToList();
            }
        }

        public List<Question> GetQuestions()
        {
            using (var db = new EvalContext())
            {
                return db.Question
                    .OrderBy(x => x.question_id)
                    .ToList();
            }
        }

        public Question GetQuestion(int questionID)
        {
            using (var db = new EvalContext())
            {
                return db.Question.Find(questionID);
            }
        }

        public List<QuestionOption> GetQuestionOptions()
        {
            using (var db = new EvalContext())
            {
                return db.Question_Option
                    .OrderBy(x => x.question_option_id)
                    .ToList();
            }
        }
    }
}

