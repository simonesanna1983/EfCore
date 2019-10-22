using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Poco.Examples
{
    public class ManyToMany
    {

        public class Student
        {
            public int StudentId { get; set; }
            public string Name { get; set; }

            public IList<StudentCourse> StudentCourses { get; set; }
        }

        public class Course
        {
            public int CourseId { get; set; }
            public string CourseName { get; set; }
            public string Description { get; set; }

            public IList<StudentCourse> StudentCourses { get; set; }
        }


        public class StudentCourse
        {
            public int StudentId { get; set; }
            public Student Student { get; set; }

            public int CourseId { get; set; }
            public Course Course { get; set; }
        }


        public class SchoolContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EFCore-SchoolDB;Trusted_Connection=True");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });
            }

            public DbSet<Student> Students { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<StudentCourse> StudentCourses { get; set; }
        }



    }
}
