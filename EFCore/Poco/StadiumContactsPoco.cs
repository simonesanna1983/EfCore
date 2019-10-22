using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCore.Poco
{
    [Table("FLV_StadiumContacts", Schema = "soa_stad_mng")]
    public class StadiumContactsPoco
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("stdContactsID", Order = 0)]
        public virtual int ContactsId { get; set; }

        [Column("stdStadiumId")]
        public  int StadiumId { get; set; }

        public  byte TypeContact { get; set; }

        public string TypeContactName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

    }

}
