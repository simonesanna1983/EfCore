using EFCore.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCore.Poco
{
    [Table("stdInspection", Schema = "soa_stad_mng")]
    public class InspectionPoco 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("stdInspectionId", Order = 0)]
        public int InspectionId { get; set; }
        //[Alias("stdStadiumId")]
        [Column("stdStadiumId")]
        public int StadiumId { get; set; }

        [Column(TypeName = "tinyint")]
        public int StatusInspection { get; set; }
        //public byte StatusInspection { get; set; }

        public DateTime? DateInspection { get; set; }
        public DateTime? DateApproved { get; set; }

        #region 2 - general info
        public bool? IsInfoFullyCompleted { get; set; }
        public string StadiumInformationComment { get; set; }
        public string StadiumInformationShortSummary { get; set; }
        #endregion

        #region 3 - staff areas - pitch
        public bool? IsFieldOfPlayCompliant { get; set; }
        public string InfrastructuresRegulationsComment { get; set; }
        #endregion

        #region 3 - staff areas - indoor facilities
        public bool? IsHomeTeamDressingRoomCompliant { get; set; }
        public string HomeTeamComment { get; set; }
        public bool? IsAwayTeamDressingRoomCompliant { get; set; }
        public string AwayTeamComment { get; set; }
        public bool? IsRefereesDressingRoomCompliant { get; set; }
        public string RefereesComment { get; set; }
        public bool? IsDelegateRoomCompliant { get; set; }
        public string DelegateRoomComment { get; set; }
        public bool? IsEmergencyMedicalRoomCompliant { get; set; }
        public string EmergencyMedicalRoomComment { get; set; }
        public bool? IsDopingControlStationCompliant { get; set; }
        public string DopingControlStationComment { get; set; }
        #endregion

        #region 3 - staff areas - floodlight
        public bool? IsFloodlightingCompliant { get; set; }
        public string FloodlightingComment { get; set; }
        public string AreasPlayersOfficialsComment { get; set; }
        #endregion

        #region 4 - spectators
        public bool? IsCapacityInformationCompliant { get; set; }
        public string CapacityInformationComment { get; set; }
        public bool? IsSpectatorFacilitiesCompliant { get; set; }
        public string SpectatorFacilitiesComment { get; set; }
        public bool? IsEquipmentsCompliant { get; set; }
        public string EquipmentsComment { get; set; }
        public string SpectatorComment { get; set; }
        #endregion

        #region 5 - media facilities
        public bool? IsMediaFacilitiesCompliant { get; set; }
        public string MediaFacilitiesComment { get; set; }
        #endregion

        #region 5 - media training
        public bool? IsMediaTribuneUEFACompliant { get; set; }
        public string MediaTribuneComment { get; set; }
        #endregion

        #region 5 - media tv
        public bool? IsTVCommentaryPositionsCompliant { get; set; }
        public string CommentaryPositionComment { get; set; }
        #endregion

        #region 5 - media camera platforms
        public bool? IsCameraPlatformsCompliant { get; set; }
        public string CameraPlatformsComment { get; set; }
        public string TVMediaFacilitiesShortSummary { get; set; }
        #endregion

        #region 7 - conclusions
        public string ConclusionGeneralInfoComment { get; set; }
        public string ConclusionStadiumOverallConditionComment { get; set; }
        public string ConclusionAccessAccommodationComment { get; set; }
        public string ConclusionSafetySecurityComment { get; set; }
        [Column(TypeName = "tinyint")]
        public int ConclusionStadiumAssessment { get; set; }
        #endregion

        #region 8 - meta
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreatedUtc { get; set; }
        public int UserUpdateId { get; set; }
        public DateTime? DateUpdateUtc { get; set; }
        #endregion

        public ICollection<StadiumPoco> Stadium { get; set; }

    }
}
