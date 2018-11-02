using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class EvaluationModel
    {
        public int evaluation_id { get; set; }

        public int course_id { get; set; }

        public string report { get; set; }

        public QuestionnaireModel questionnaire { get; set; }
        
    }
}
