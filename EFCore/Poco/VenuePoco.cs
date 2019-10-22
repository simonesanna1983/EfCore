using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCore.Poco
{
    [Table("xgeoVenue", Schema = "soa_stad_mng")]
    public class VenuePoco
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("xgeoVenueID", Order = 0)]
        public int VenueId { get; set; }
        [Column("xgeoCountryID")]
        public int CountryId { get; set; }
        public string VenueName { get; set; }
        public string DisplayName { get; set; }
        public string NormalizeName { get; set; }
        public string VenueCode { get; set; }
        [Column(TypeName = "tinyint")]
        public int StatusVenue { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }


    }
}
