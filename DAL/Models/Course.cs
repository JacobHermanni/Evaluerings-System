using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using DAL.Models;

namespace DAL.Models
{
    public class Course
    {
        [Key]
        public int course_id { get; set; }

        public string course_name { get; set; }

        public Evaluation evaluation
        {
            get
            {
                using (var db = new EvalContext())
                {
                    var getEvals = db.Evaluation.Where(x => x.evaluation_id == course_id);
                    if (!getEvals.Any()) return null;

                    // first() fordi Iqueryable er en liste
                    return getEvals.First();
                }
            }
            set { }
        }
    }
}
