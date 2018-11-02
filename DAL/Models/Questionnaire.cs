using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DAL.Models
{
    public class Questionnaire
    {
        [Key]
        public int questionnaire_id { get; set; }

        public int evaluation_id { get; set; }

        public string description { get; set; }

        public List<Question> questions
        {
            get
            {
                using (var db = new EvalContext())
                {
                    var getQuestions = db.Question.Where(x => x.questionnaire_id == questionnaire_id);
                    
                    if (!getQuestions.Any()) return null;
                    
                    return getQuestions.ToList();
                }
            }
            set { }
        }
    }
}
