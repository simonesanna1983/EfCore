using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCore.Poco;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Configuration.EfCore
{
    public class MemoryContext : DbContext
    {
        public DbSet<InspectionPoco> InspectionDbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(
                    @"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");

            }
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Query<InspectionPoco>().ToQuery(() =>
            //    InspectionDbSet.Select(m => new InspectionPoco()
            //               {
            //                   InspectionId = 1,
            //                   StadiumId = 14,
            //                   StadiumInformationComment = "Something to comment on ...",
            //               }
            //              ));



        }



    }




}
