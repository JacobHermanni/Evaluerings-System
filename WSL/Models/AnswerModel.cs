using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class AnswerModel
    {
        public int answer_id { get; set; }

        public int questionnaire_id { get; set; }

        public int answer { get; set; }

        public int student_id { get; set; }

        public int question_id { get; set; }

    }
}