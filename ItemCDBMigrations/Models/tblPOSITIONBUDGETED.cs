namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPOSITIONBUDGETED")]
    public partial class tblPOSITIONBUDGETED
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPOSITIONBUDGETED()
        {
            tblPOSITIONACTUALs = new HashSet<tblPOSITIONACTUAL>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BudPosNum { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name ="Budgeted Item")]
        public string BudItemNum { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name ="Budgeted SubItem")]
        public string BudSubItem { get; set; }

        [Required]
        public int BudOrd { get; set; }

        [Required]
        public int BudBud { get; set; }

        [Required]
        public int BudFilled { get; set; }

        [Required]
        [StringLength(1)]
        public string BudFunction { get; set; }

        [StringLength(10)]
        public string BudOrgCode { get; set; }

        [Required]
        public int BudDivCode { get; set; }

        [Required]        
        public int BudSecCode { get; set; }

        [Required]
        public int BudUnitCode { get; set; }

        public string Comments { get; set; }

        /*[Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] SSMA_TimeStamp { get; set; }*/

        public virtual tblBud tblBud { get; set; }

        public virtual tblBudItemNum tblBudItemNum { get; set; }

        public virtual tblDivision tblDivision { get; set; }

        public virtual tblFilled tblFilled { get; set; }

        public virtual tblFunction tblFunction { get; set; }

        public virtual tblOrd tblOrd { get; set; }

        public virtual tblOrgCode tblOrgCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPOSITIONACTUAL> tblPOSITIONACTUALs { get; set; }

        public virtual tblSubItem tblSubItem { get; set; }

        public virtual tblSection tblSection { get; set; }

        public virtual tblUnit tblUnit { get; set; }
    }
}
