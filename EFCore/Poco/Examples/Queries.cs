using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Poco.Examples
{
    public class Queries
    {


        public void DoQuery()
        {


            //using (var db = new ManyToMany.Student())
            //{
            //    var student = new ManyToMany.Student()
            //      { //Root entity (with key value)
            //          StudentId = 1,
            //          Name = "Bill",
            //          StudentCourses = new List<ManyToMany.StudentCourse>() {
            //              new ManyToMany.StudentCourse(){  Course = new ManyToMany.Course(){ CourseName="Machine Language" } },//Child entity (empty key)
            //              new ManyToMany.StudentCourse(){  Course = new ManyToMany.Course(){  CourseId=2 } } //Child entity (with key value)
            //          }
            //      };

            //    db.SaveChanges();
            //}



            /*

             QUERY 1

             var studentWithGrade = context.Students
                           .Where(s => s.FirstName == "Bill")
                           .Include(s => s.Grade)
                           .FirstOrDefault();


                SELECT TOP(1) [s].[StudentId], [s].[DoB], [s].[FirstName], [s].[GradeId],[s].[LastName], 
                        [s].[MiddleName], [s.Grade].[GradeId], [s.Grade].[GradeName], [s.Grade].[Section]
                FROM [Students] AS [s]
                LEFT JOIN [Grades] AS [s.Grade] ON [s].[GradeId] = [s.Grade].[GradeId]
                WHERE [s].[FirstName] = N'Bill'

----------------------------------------------------

                var context = new SchoolContext();
                

                ANOTHER WAY TO WRITE QUERY 1
                var studentWithGrade = context.Students
                                        .FromSql("Select * from Students where FirstName ='Bill'")
                                        .Include(s => s.Grade)
                                        .FirstOrDefault();     




             */

            /*
             *
             * Lazy Loading
Lazy loading is not supported in Entity Framework Core 2.0. Track lazy loading issue on github.


https://www.entityframeworktutorial.net/efcore/querying-in-ef-core.aspx

             */


        }

    }
}
