using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Poco
{
    public class StadiumViewPoco
    {
        public int StadiumId { get; set; }
        public string OfficialName { get; set; }
        public string SponsorName { get; set; }
        public string SpecialEventsName { get; set; }
        public string MediaName { get; set; }
        public string NormalizeName { get; set; }
        public int? VenueId { get; set; }
        public int? TypeStadiumOwner { get; set; }
        public string StadiumOwnerFreeText { get; set; }
        public OperationalStatus? StatusOperational { get; set; }
        public string Notes { get; set; }
        public int? ProposedCategoryId { get; set; }
        public int? CategoryId { get; set; }

        public int? CountryId { get; set; }
        public string VenueName { get; set; }
        public string VenueCode { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string DesignatedOfficialName { get; set; }
        //public int? FcompStadiumId { get; set; }
    }


    public enum OperationalStatus
    {
        Completed = 1,
        UnderRenovation = 2,
        UnderConstruction = 3,
        Demolished = 4
    }
}
