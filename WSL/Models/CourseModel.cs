using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class CourseModel
    {
        public int course_id { get; set; }

        public string course_name { get; set; }
    }
}