using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DAL.Models
{
    public class Evaluation
    {
        [Key]
        public int evaluation_id { get; set; }

        public int course_id { get; set; }

        public string report { get; set; }

        [NotMapped]
        public List<Questionnaire> questionnaires
        {
            get
            {
                using (var db = new EvalContext())
                {
                    var getQuestionnaires = db.Questionnaire.Where(x => x.evaluation_id == this.evaluation_id).ToList();
                    if (!getQuestionnaires.Any()) return null;
                    
                    return getQuestionnaires;
                }
            }
            set { }
        }
    }
}