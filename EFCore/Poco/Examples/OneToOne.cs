using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Poco.Examples
{
    public class OneToOne
    {

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public StudentAddress Address { get; set; }
        }

        public class StudentAddress
        {
            public int StudentAddressId { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }

            public int AddressOfStudentId { get; set; }
            public Student Student { get; set; }
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
                    .HasOne<StudentAddress>(s => s.Address)
                    .WithOne(ad => ad.Student)
                    .HasForeignKey<StudentAddress>(ad => ad.AddressOfStudentId);
            }

            public DbSet<Student> Students { get; set; }
            public DbSet<StudentAddress> StudentAddresses { get; set; }
        }



    }
}
