using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Text;

namespace EFCore.Poco
{
    [Table("stdStadium", Schema = "soa_stad_mng")]
    public class StadiumPoco 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("stdStadiumId", Order = 0)]
        public virtual int StadiumId { get; set; }
        public string OfficialName { get; set; }
        public string SponsorName { get; set; }
        public string SpecialEventsName { get; set; }
        public string MediaName { get; set; }
        public string NormalizeName { get; set; }
        public int? VenueId { get; set; }
        [Column(TypeName = "tinyint")]
        public int? TypeStadiumOwner { get; set; }
        public string StadiumOwnerFreeText { get; set; }
        public OperationalStatus? StatusOperational { get; set; }
        public string Notes { get; set; }
        public int? ProposedCategoryId { get; set; }
        [Column("stdCategoryID")]
        public int? CategoryId { get; set; }
    }
}
