using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Poco.Examples
{
    //Explanation
    //https://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx
    public class OneToMany
    {

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public int CurrentGradeId { get; set; }
            public Grade Grade { get; set; }
        }

        public class Grade
        {
            public int GradeId { get; set; }
            public string GradeName { get; set; }
            public string Section { get; set; }

            public ICollection<Student> Students { get; set; }
        }


        public class SchoolContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EFCore-SchoolDB;Trusted_Connection=True");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Student>()
                    .HasOne<Grade>(s => s.Grade)
                    .WithMany(g => g.Students)
                    .HasForeignKey(s => s.CurrentGradeId);
            }

            public DbSet<Grade> Grades { get; set; }
            public DbSet<Student> Students { get; set; }
        }


    }
}
