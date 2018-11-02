using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class QuestionOption
    {
        [Key]
        public int question_option_id { get; set; }

        public int question_id { get; set; }

        public string choice { get; set; }

        public bool freetext { get; set; }
    }
}
