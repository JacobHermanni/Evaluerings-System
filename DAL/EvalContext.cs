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

        public DbSet<Answer> Answer { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql(
                "server=localhost;" +
                "database=evaluation;" +
                "uid=root;" +
                "pwd=root;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}

