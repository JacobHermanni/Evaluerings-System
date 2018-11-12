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

        public List<Question> GetQuestionsFromQuestionBank(int questionnaireID)
        {
            using (var db = new EvalContext())
            {
                return db.Question
                    .Where(q => q.questionnaire_id == questionnaireID)
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
        public Evaluation GetEvaluation (int evaluationID)
        {
            using (var db = new EvalContext())
            {
                return db.Evaluation.Find(evaluationID);
            }
        }

        public Question CreateQuestionInBank(int questionID, string description)
        {
            using (var db = new EvalContext())
            {
                // tjek for eksisterende question. Hvis der er en så returner null, da redigering ikke skal ske gennem Create (rest)
                var existingQuestion = db.Question.Find(questionID);

                if (existingQuestion != null) return null;

                var question = new Question
                {
                    question_id = questionID,
                    questionnaire_id = 1337,
                    description = description
                };

                db.Question.Add(question);

                db.SaveChanges();

                return question;
            }
        }

        public Question CreateQuestionOnQuestionnaire(int questionnaireID, int questionID, string description)
        {
            using (var db = new EvalContext())
            {
                // tjek for eksisterende question. Hvis der er en så returner null, da redigering ikke skal ske gennem Create (rest)
                var existingQuestion = db.Question.Find(questionID);

                if (existingQuestion != null) return null;

                var question = new Question
                {
                    question_id = questionID,
                    questionnaire_id = questionnaireID,
                    description = description
                };

                db.Question.Add(question);

                db.SaveChanges();

                return question;
            }
        }

        public bool DeleteQuestion(int questionID)
        {
            using (var db = new EvalContext())
            {
                var existingQuestion = db.Question.Find(questionID);

                if (existingQuestion != null)
                {
                    db.Question.Remove(existingQuestion);
                    db.SaveChanges();
                    return true;
                }
            }
            // statuscode kræver false hvis der ikke kunne findes noget at slette og true, hvis der var noget at slette som slettes.
            return false;
        }

        public List<Answer> GetAnswers()
        {
            using (var db = new EvalContext())
            {
                return db.Answer
                    .OrderBy(x => x.answer_id)
                    .ToList();
            }
        }

        public List<Answer> GetAnswersFromQuestionnaire(int questionnaireID)
        {
            using (var db = new EvalContext())
            {
                return db.Answer
                    .Where(a => a.questionnaire_id == questionnaireID)
                    .OrderBy(x => x.answer_id)
                    .ToList();
            }
        }

        public Evaluation AddReport(int evaluationID, string report)
        {
            using (var db = new EvalContext())
            {
                //var existingEvaluation = db.Evaluation.AsNoTracking().Where(e => e.evaluation_id == evaluationID).First();
                var existingEvaluation = db.Evaluation.Find(evaluationID);
                existingEvaluation.report = report;

                db.Evaluation.Attach(existingEvaluation);
                var entry = db.Entry(existingEvaluation);
                entry.Property(x => x.report).IsModified = true;

                db.SaveChanges();

                
                return existingEvaluation;
            }


        }

        public void  CreateAnswer(int question_id, int questionnaire_id, int answer)
        {
            using (var db = new EvalContext())
            {
                var studyanswer = new Answer
                {
                   
                    question_id = question_id,
                    questionnaire_id = questionnaire_id,
                    answer = answer
                   
                };

                db.Answer.Add(studyanswer);

                db.SaveChanges();

                // returner den nyoprettede answer
                //return GetAnswers();
            }
        }

    }
}

