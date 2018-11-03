using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using DAL.Models;
namespace DAL.Models
{
    public class Answer
    {
        [Key]
        public int answer_id { get; set; }

        public int evaluation_id { get; set; }

        public int answer { get; set; }

        public int student_id { get; set; }

        public int question_id { get; set; }


    }
}




