using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using EFCore.Poco;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Configuration.EfCore
{
    /*

    The DbContext is an instance of DbContext represents a session with the database which can be used to query and save instances of your entities to a database

        To use DbContext in our application, we need to create the class that derives from DbContext, also known as context class. 
        This context class typically includes DbSet<TEntity> properties for each entity in the model. Consider the following example of context class in EF Core.


        The OnConfiguring() method allows us to select and configure the data source to be used with a context using DbContextOptionsBuilder. 
        Learn how to configure a DbContext class at here.


        The OnModelCreating() method allows us to configure the model using ModelBuilder Fluent API.

        FIRST EXAMPLE

        namespace EFCoreTutorials
        {
            class Program
            {
                static void Main(string[] args)
                {
                    using (var context = new SchoolContext()) {
        
                        var std = new Student()
                        {
                             Name = "Bill"
                        };
        
                        context.Students.Add(std);
                        context.SaveChanges();
                    }
                }
            }
        }


        QUERYING
        private static void Main(string[] args)
        {
            var context = new SchoolContext();
            var studentsWithSameName = context.Students
                                              .Where(s => s.FirstName == GetName())
                                              .ToList();
        }
        
        public static string GetName() {
            return "Bill";
        }


    */

    public class EfContext : DbContext
    {
        public DbSet<InspectionPoco> InspectionDbSet { get; set; }
        public DbSet<StadiumPoco> StadiumDbSet { get; set; }
        public DbSet<VenuePoco> VenueDbSet { get; set; }
        public DbSet<DesignationPoco> DesignationDbSet { get; set; }
        public DbSet<UserPoco> UserDbSet { get; set; }
        public DbSet<StadiumContactsPoco> StadiumContactsDbSet { get; set; }


        //public EfContext(DbContextOptions<EfContext> options)
        //    : base(options)
        //{ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=si-fdpr-03\football;Initial Catalog=SMS;Persist Security Info=True;User ID=sa;Password=sharm;MultipleActiveResultSets=True");
            //ChangeTracker.AutoDetectChangesEnabled = false;


        }


        //public override int SaveChanges()
        //{
        //    var changedEntities = ChangeTracker
        //        .Entries()
        //        .Where(_ => _.State == EntityState.Added ||
        //                    _.State == EntityState.Modified);

        //    var errors = new List<ValidationResult>(); // all errors are here
        //    foreach (var e in changedEntities)
        //    {
        //        var vc = new ValidationContext(e.Entity, null, null);
        //        Validator.TryValidateObject(  //validated attributes 
        //            e.Entity, vc, errors, validateAllProperties: true);
        //    }

        //    return base.SaveChanges();
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<InspectionPoco>(entity =>
            //    {
            //        entity.Property(e => e.InspectionId).HasColumnName("stdInspectionId");
            //        entity.Property(e => e.StadiumId).HasColumnName("stdStadiumId");

            //        entity.Property(e => e.Description)
            //            .IsRequired()
            //            .HasMaxLength(500);

            //        entity.Property(e => e.Icon)
            //            .IsRequired()
            //            .HasMaxLength(10);

            //        entity.Property(e => e.Main)
            //            .IsRequired()
            //            .HasMaxLength(50);

            //        entity.Property(e => e.OpenWeatherCityId).HasColumnName("OpenWeatherCityID");

            //        entity.Property(e => e.OpenWeatherId).HasColumnName("OpenWeatherID");
            //    });


            //modelBuilder.Entity<StadiumPoco>()
            //    .HasOne<InspectionPoco>(s => s.StadiumId)
            //    .WithMany(g => g.InspectionId)
            //    .HasForeignKey(s => s.StadiumId);


            //if (Database.IsSqlServer())
            //{
            //    //modelBuilder.Query<InspectionPoco>(entity =>
            //    //{
            //    //    entity.ToView("vGetProviderRatingData", "dbo");
            //    //    entity.Property(e => e.col1)
            //    //        .HasMaxLength(10)
            //    //        .IsUnicode(false);
            //    //    entity.Property(e => e.col2)
            //    //        .HasMaxLength(60)
            //    //        .IsUnicode(false);
            //    //    entity.Property(e => e.col3)
            //    //        .HasMaxLength(10)
            //    //        .IsUnicode(false);

            //    //});
            //}
            //else
            //{
            //    modelBuilder.Query<InspectionPoco>().ToQuery(() =>
            //        InspectionDbSet.Select(m => new InspectionPoco()
            //            {
            //                InspectionId = 1,
            //                StatusInspection = 2,
            //                StadiumInformationComment = "Something to comment on...",
            //            }
            //        ));
            //}





        }


    }
}
