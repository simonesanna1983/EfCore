using EFCore.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCore.Configuration.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCore.Repository
{

    public interface IInspectionRepository
    {
        InspectionPoco GetInspection(int inspectionId, int stadiumId);
        StadiumViewPoco GetStadiumViewByInspectionId(int inspectionId, int stadiumId);

        void UpsertInspection(InspectionPoco poco);

        void UpsertInspectionRage(IEnumerable<int> poco);
        void SkipAndTakeInspection(int skip, int take);

        void OtherExampleOfLeftJoin();

        void UpdateFromView(int contactId, string email);
    }

    public class SqlEfCoreInspectionRepository : IInspectionRepository
    {

        //private readonly IDbConnectionFactory _dbConnectionFactory;

        //public SqlEfCoreInspectionRepository(IDbConnectionFactory dbConnectionFactory)
        //{
        //    _dbConnectionFactory = dbConnectionFactory;
        //}

        public InspectionPoco GetInspection(int inspectionId, int stadiumId)
        {
            using (var db = new EfContext())

            {
                var inspection = db.InspectionDbSet
                    .Single(x => x.InspectionId == inspectionId);

                if (inspection == null)
                    throw new Exception("Inspection not found");
                return inspection;

            }

            //using (var context = serviceProvider.GetService<BloggingContext>())
            //{
            //    // do stuff
            //}

        }


        public StadiumViewPoco GetStadiumViewByInspectionId(int inspectionId, int stadiumId)
        {
            using (var db = new EfContext())
            {
                var inspection = db.InspectionDbSet;
                var stadium = db.StadiumDbSet;
                var venue = db.VenueDbSet;
                var designation = db.DesignationDbSet;
                var user = db.UserDbSet;

                var q = stadium.GroupJoin(venue,
                        a => a.VenueId,
                        b => b.VenueId,
                       (a, b) => new { stadium = a, venue = b, inspectionId = inspectionId })
                            .SelectMany(g => g.venue.DefaultIfEmpty(), (a, b) => new { a.stadium, venue = (VenuePoco)null, inspectionId = inspectionId })
                            .GroupJoin(designation,
                                    a => a.inspectionId,
                                    b => b.InspectionId,
                                    (a, b) => new { stadium = a.stadium, venue = a.venue, inspectionId = a.inspectionId, designation = b })
                            .SelectMany(g => g.designation.DefaultIfEmpty(), (a, b) => new { stadium = a.stadium, venue = a.venue, designation = b, inspectionId = inspectionId })
                            .GroupJoin(user,

                                    a => a.designation.PersonId,
                                    b => b.XedsPersonId,
                                    (a, b) => new { stadium = a.stadium, venue = a.venue, inspectionId = a.inspectionId, designation = a.designation, user = b })
                            .SelectMany(g => g.user.DefaultIfEmpty(), (a, b) => new { stadium = a.stadium, venue = a.venue, designation = a.designation, user = (UserPoco)null, inspectionId = a.inspectionId })
                            .Select(x => new
                            {
                                x.stadium,
                                x.user,
                                x.venue,
                                x.inspectionId,
                                x.designation,
                            })
                            .Where(x => x.stadium.StadiumId == stadiumId)
                            ;

                var result = q.ToList().SingleOrDefault();

                return new StadiumViewPoco
                {
                    StadiumId = result.stadium.StadiumId,
                    //FcompStadiumId = tuple.Item1.FcompStadiumId,
                    OfficialName = result.stadium.OfficialName,
                    SponsorName = result.stadium.SponsorName,
                    SpecialEventsName = result.stadium.SpecialEventsName,
                    MediaName = result.stadium.MediaName,
                    NormalizeName = result.stadium.NormalizeName,
                    VenueId = result.stadium.VenueId,
                    TypeStadiumOwner = result.stadium.TypeStadiumOwner,
                    StadiumOwnerFreeText = result.stadium.StadiumOwnerFreeText,
                    StatusOperational = result.stadium.StatusOperational,
                    Notes = result.stadium.Notes,
                    ProposedCategoryId = result.stadium.ProposedCategoryId,
                    CategoryId = result.stadium.CategoryId,

                    CountryId = result.venue.CountryId,
                    VenueName = result.venue.VenueName,
                    VenueCode = result.venue.VenueCode,
                    CountryCode = result.venue.CountryCode,
                    CountryName = result.venue.CountryName,
                    DesignatedOfficialName = result.user.XedsPersonId > 0 ? $"{result.user.FirstName} {result.user.LastName}" : string.Empty
                };

            }
        }


        public void UpsertInspection(InspectionPoco poco)
        {

            using (var db = new EfContext())
            {

                db.Entry(poco).State = poco.InspectionId > 0 ? EntityState.Modified : EntityState.Added;

                var resp = db.SaveChanges();

                //db.Entry(poco).Property("StatusInspection").IsModified = true;

                //db.ChangeTracker.TrackGraph(poco, e => {
                //    if (e.Entry.IsKeySet)
                //    {
                //        e.Entry.State = EntityState.Modified;
                //    }
                //    else
                //    {
                //        e.Entry.State = EntityState.Added;
                //    }
                //});


            }


        }

        public void UpsertInspectionRage(IEnumerable<int> inspectionIds)
        {
            using (var db = new EfContext())
            {
                var pocos = new List<InspectionPoco>();

                DisplayStates(db.ChangeTracker.Entries());

                foreach (var inspectionId in inspectionIds)
                {
                    // try to retrieve existing entity
                    var retrieveInspectionPoco = db.InspectionDbSet.Find(inspectionId);  

                    // if entity does not already exist -> create new
                    if (retrieveInspectionPoco == null)
                    {
                        retrieveInspectionPoco = new InspectionPoco();

                        db.InspectionDbSet.Add(retrieveInspectionPoco);
                    }

                    //Example to remove a record
                    //if (inspectionId == 685)
                    //{
                    //    db.InspectionDbSet.Remove(retrieveInspectionPoco);

                    //}

                    //if necessary, set the properties or map received values
                    retrieveInspectionPoco.StatusInspection = 2;

                }

                // EntityState should be set automatically by EF ChangeTracker
                // you can see all the operation during the save changes
                DisplayStates(db.ChangeTracker.Entries());


                var resp = db.SaveChanges();

            }
        }



        public void OtherExampleOfLeftJoin()
        {
            using (var db = new MemoryContext())
            {
                var studentWithGrade = db.InspectionDbSet.Where(s => s.StatusInspection == 2)
                    .Include(s => s.StadiumId)
                    .FirstOrDefault();
            }

        }


        public void SkipAndTakeInspection(int numberOfSkip , int numberOfTake)
        {
            using (var db = new EfContext())
            {
                IQueryable<VenuePoco> query = db.VenueDbSet.OrderBy(x => x.VenueId).Skip(numberOfSkip).Take(numberOfTake);
                query.ToList();
            }
        }


        public void UpdateFromView(int contactId,string email)
        {

            using (var db = new EfContext())
            {
                var retrieveInspectionPoco = db.StadiumContactsDbSet.Find(contactId);

                retrieveInspectionPoco.Email = email;


                db.SaveChanges();
            }



        }

        private static void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: { entry.State.ToString()}");
            }
        }



        private InspectionPoco GetMockInspection1(int stadiumId)
        {
            return new InspectionPoco()
            {
                StadiumId = stadiumId,
                StatusInspection = 2,
                StadiumInformationComment = "A",

            }; 
        }

        private InspectionPoco GetMockInspection(int stadiumId)
        {
            return new InspectionPoco()
            {
                StadiumId = stadiumId,
                StatusInspection = 1,
                StadiumInformationComment = "A",

            };
        }





        //var student = new Student()
        //{ //Root entity (with key value)
        //    StudentId = 1,
        //    Name = "Bill",
        //    Address = new StudentAddress()  //Child entity (with key value)
        //    {
        //        StudentAddressId = 1,
        //        City = "Seattle",
        //        Country = "USA"
        //    },
        //    StudentCourses = new List<StudentCourse>() {
        //        new StudentCourse(){  Course = new Course(){ CourseName="Machine Language" } },//Child entity (empty key)
        //        new StudentCourse(){  Course = new Course(){  CourseId=2 } } //Child entity (with key value)
        //    }
        //};





    }

}

