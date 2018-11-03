using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class QuestionModel
    {
        public int question_id { get; set; }

        public int questionnaire_id { get; set; }

        public string description { get; set; }
    }
}
