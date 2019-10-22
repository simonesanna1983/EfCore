using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCore.Poco
{
    [Table("stdUser", Schema = "soa_stad_mng")]
    public class UserPoco
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("XedsPersonId", Order = 0)]
        public int XedsPersonId { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Column("StatusUserPerson", TypeName = "tinyint")]
        public int StatusUser { get; set; }
        [Column("xedsOrganizationID")]
        public int OrganizationId { get; set; }
        public long TypeTeamBW { get; set; }
        [Column(TypeName = "tinyint")]
        public int StadiumRole { get; set; }
        public bool IsTimeUser { get; set; }
        public bool IsConsultant { get; set; }
        public bool IsOfficial { get; set; }
        public int? RealOrganizationId { get; set; }
        public bool IsOfficialList { get; set; }

    }
}
