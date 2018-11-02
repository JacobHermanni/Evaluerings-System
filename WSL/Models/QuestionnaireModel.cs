using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class QuestionnaireModel
    {
        public int questionnaire_id { get; set; }

        public int evaluation_id { get; set; }

        public string description { get; set; }

        public List<QuestionModel> questions { get; set; }
    }
}
