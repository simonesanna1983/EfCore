using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCore.Poco
{
    [Table("stdDesignation", Schema = "soa_stad_mng")]
    public class DesignationPoco
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("stdInspectionID", Order = 0)]
        public int InspectionId { get; set; }
        [Column(TypeName = "tinyint")]
        public int? StatusValidation { get; set; }
        [Column("xedsPersonID")]
        public int? PersonId { get; set; }
        [Column("foffDesignationID")]
        public int? DesignationId { get; set; }
    }


}
