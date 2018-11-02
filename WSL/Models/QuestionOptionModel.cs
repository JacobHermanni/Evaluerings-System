using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class QuestionOptionModel
    {
        public int question_option_id { get; set; }

        public int question_id { get; set; }

        public string choice { get; set; }

        public bool freetext { get; set; }
    }
}
