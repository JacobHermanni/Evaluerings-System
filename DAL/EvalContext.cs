using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{
    public class EvalContext : DbContext
    {
        // database mapping to class models

        public DbSet<Course> Course { get; set; }

        public DbSet<Evaluation> Evaluation { get; set; }

        public DbSet<Questionnaire> Questionnaire { get; set; }

        public DbSet<Question> Question { get; set; }

<<<<<<< Updated upstream
=======
        public DbSet<QuestionOption> Question_Option { get; set; }

        public DbSet<Answer> Answer { get; set; }
>>>>>>> Stashed changes

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql(
                "server=localhost;" +
                "database=evaluation;" +
                "uid=root;" +
<<<<<<< HEAD
<<<<<<< Updated upstream
                "pwd=root;"
=======
                "pwd=root050191;"
>>>>>>> Stashed changes
=======
                "pwd=theis9953;"
>>>>>>> 66cea53... * DataService.cs: * IDataService.cs: * WebService.csproj: * QuestionModel.cs: * AnswerController.cs: * QuestionController.cs:
            );
        }

        // f鴕 modellerne i EF er lavet kan vi override nogle selvdefinerede regler mm.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key defineres her
            //modelBuilder.Entity<Tags>().HasKey(t => new { t.post_id, t.tag });

        }

    }
}

