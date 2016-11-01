namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblEMPLOYEELIST")]
    public partial class tblEMPLOYEELIST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEMPLOYEELIST()
        {
            tblPOSITIONACTUALs = new HashSet<tblPOSITIONACTUAL>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmplID { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(10)]
        public string MiddleName { get; set; }

        [StringLength(10)]
        public string NameSuffix { get; set; }

        [Required]
        [StringLength(1)]
        public string EmplStatus { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? SeniorityDate { get; set; }

        [StringLength(10)]
        public string PayLoc { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? BirthDate { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        public int? Ethnicity { get; set; }

        public string Comments { get; set; }

        [StringLength(8)]
        public string ehrPositionID { get; set; }

        [StringLength(5)]
        public string ehrUnitNumber { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] SSMA_TimeStamp { get; set; }

        public virtual tblPayLocation tblPayLocation { get; set; }

        public virtual tblEmplStatu tblEmplStatu { get; set; }

        public virtual tblEthnicity tblEthnicity { get; set; }

        public virtual tblGender tblGender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPOSITIONACTUAL> tblPOSITIONACTUALs { get; set; }
    }
}
