﻿using System;
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

        public Question CreateQuestion(int questionID, string description)
        {
            using (var db = new EvalContext())
            {
                // tjek for eksisterende question. Hvis der er en så returner null, da redigering ikke skal ske gennem Create (rest)
                var existingQuestion = GetQuestion(questionID);

                if (existingQuestion != null) return null;

                var question = new Question
                {
                    question_id = questionID,
                    questionnaire_id = 0,
                    description = description,
                    questionOptions = null
                };

                db.Question.Add(question);

                db.SaveChanges();

                // returner den nyoprettede note
                return GetQuestion(questionID);
            }
        }

        public bool DeleteQuestion(int questionID)
        {
            using (var db = new EvalContext())
            {
                var existingQuestion = db.Question.Find(questionID);

                if (existingQuestion != null)
                {
                    var children = db.Question_Option.Where(x => x.question_id == questionID).ToList();
                    if(children.Count != 0)
                    {
                        foreach(var child in children)
                        {
                            db.Question_Option.Remove(child);
                        }
                    }
                    db.Question.Remove(existingQuestion);
                    db.SaveChanges();
                    return true;
                }
            }
            // statuscode kræver false hvis der ikke kunne findes noget at slette og true, hvis der var noget at slette som slettes.
            return false;
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

        public List<Answer> GetAnswers()
        {
            using (var db = new EvalContext())
            {
                return db.Answer
                    .OrderBy(x => x.answer_id)
                    .ToList();
            }
        }
    }
}

