namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// The Model Table for the Employees 'tblEMPLOYEELIST'.
    /// It has all the fields and relationships.
    /// All the models are named exactly as their respective Tables on the Database.    
    /// </summary>
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
        [StringLength(30)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [StringLength(20)]
        [Display(Name ="Middle Name")]
        public string MiddleName { get; set; }

        [StringLength(10)]
        [Display(Name ="Name Suffix")]
        public string NameSuffix { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name ="Status")]
        public string EmplStatus { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name ="Seniority Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime? SeniorityDate { get; set; }

        [StringLength(10)]
        [Display(Name ="Pay Location")]
        public string PayLoc { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name ="Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime? BirthDate { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        public int? Ethnicity { get; set; }

        public string Comments { get; set; }

        [StringLength(8)]
        public string ehrPositionID { get; set; }

        [StringLength(5)]
        public string ehrUnitNumber { get; set; }

        // REMOVED this column because it was creating bugs and it was not needed.
        /*[Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] SSMA_TimeStamp { get; set; }*/

        public virtual tblPayLocation tblPayLocation { get; set; }

        public virtual tblEmplStatu tblEmplStatu { get; set; }

        public virtual tblEthnicity tblEthnicity { get; set; }

        public virtual tblGender tblGender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPOSITIONACTUAL> tblPOSITIONACTUALs { get; set; }
    }
}
