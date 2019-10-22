using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.Enum;
using EFCore.Poco;
using FluentAssertions;
using NUnit.Framework;
using Test;

namespace Tests
{
    public class Tests
    {
        private ConfigureServices _service { get; set; }

        [SetUp]
        public void Setup()
        {
            _service = new ConfigureServices();
            _service.ConfigureEFCore();

            _service.ConfigureEFCoreInMemory();

        }

        [TestCase(116, 62415)]
        public void GetInspectionById(int inspectionId, int stadiumId)
        {
            var inspectionRepository = _service.GetSqlEfCoreInspectionRepository();

            var resp = inspectionRepository.GetInspection(inspectionId, stadiumId);

            resp.Should().NotBeNull();

        }


        [TestCase(116, 62415)]
        public void GetStadiumViewByInspectionId(int inspectionId, int stadiumId)
        {
            var inspectionRepository = _service.GetSqlEfCoreInspectionRepository();

            var resp = inspectionRepository.GetStadiumViewByInspectionId(inspectionId, stadiumId);

            resp.Should().NotBeNull();
        }


        [TestCase(116, 62415, "This is a Test")]
        public void UpsertInspectionInsert(int inspectionId, int stadiumId, string StadiumInformationComment)
        {
            var inspectionRepository = _service.GetSqlEfCoreInspectionRepository();

            //load inspection
            var inspectionPoco = inspectionRepository.GetInspection(inspectionId, stadiumId);
            inspectionPoco.Should().NotBeNull();


            //change StadiumInformationComment content
            inspectionPoco.StadiumInformationComment = StadiumInformationComment;

            //save
             inspectionRepository.UpsertInspection(inspectionPoco);

        }


        [TestCase(62415)]  // do update
        public void UpsertInspectionRange(int stadiumId)
        {
            var inspectionRepository = _service.GetSqlEfCoreInspectionRepository();

            ////load inspection
            //var inspectionPoco1 = inspectionRepository.GetInspection(inspectionId, stadiumId);
            //inspectionPoco1.Should().NotBeNull();

            var inspectionIds = new List<int>()
            {
                683,   //if the inspection id exist into DB then do update otherwise do insert
                684,
                685
            };


            //save
            inspectionRepository.UpsertInspectionRage(inspectionIds);

        }


        [TestCase(5,10)]  // do update
        public void SkipAndTakeInspection(int numberOfSkip, int numberOfTake)
        {
            var inspectionRepository = _service.GetSqlEfCoreInspectionRepository();

            inspectionRepository.SkipAndTakeInspection(numberOfSkip, numberOfTake);

        }

        [Test]
        public void OtherExampleOfLeftJoin()
        {
            var inspectionRepository = _service.GetSqlEfCoreInspectionRepository();

            inspectionRepository.OtherExampleOfLeftJoin();

        }


        [Test]
        public void QueryInMemory()
        {
            var inspectionRepository = _service.GetInMemoryEFCoreInspectionRepository();

            var inspectionPoco = new InspectionPoco()
            {
                StadiumId = 34,
                StadiumInformationComment = "Something to comment on ..."
            };

            var inspectionId1 = inspectionRepository.AddInspection(inspectionPoco);

            inspectionId1.Should().BeGreaterThan(0);

        }




    }
}