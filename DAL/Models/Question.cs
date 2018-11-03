using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DAL.Models
{
    public class Question
    {
        [Key]
        public int question_id { get; set; }

        public int questionnaire_id { get; set; }

        public string description { get; set; }

    }
}
