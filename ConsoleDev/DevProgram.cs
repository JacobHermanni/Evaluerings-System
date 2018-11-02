using System;
using DAL;

namespace ConsoleDev
{
    class DevProgram
    {
        static void Main(string[] args)
        {
            //AnswerTest();
            QuestionTest();
            
        }

        static void QuestionTest()
        {
            var evaldb = new DataService();

            var courses = evaldb.GetCourses();

            Console.WriteLine(courses[0].course_name);
  


            Console.Read();

        }
    }
}
