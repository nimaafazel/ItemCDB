namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPOSITIONACTUAL")]
    public partial class tblPOSITIONACTUAL
    {
        [Key]
        public int ActPosAutoID { get; set; }

        [Display(Name ="Position Number")]
        public int ActPosNum { get; set; }

        [Display(Name ="Employee ID")]
        public int EmplID { get; set; }

        [Display(Name ="Effective Date")]
        [Column(TypeName = "datetime2")]
        public DateTime EffectiveDate { get; set; }

        [Display(Name ="Hire Date")]
        [Column(TypeName = "datetime2")]
        public DateTime? DeptHireDate { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name ="Status")]
        public string ActEmplStatus { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name ="Item Number")]
        public string ActItemNum { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name ="SubItem Number")]
        public string ActSubItem { get; set; }

        [StringLength(50)]
        public string Step { get; set; }

        [Column(TypeName = "money")]
        [Display(Name ="Pay Rate")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        public decimal? PayRate { get; set; }

        [Display(Name ="Pay Period")]
        public int? PayPeriod { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name ="Employment Type")]
        public string EmplType { get; set; }

        [StringLength(10)]
        [Display(Name ="PreItem Number")]
        public string PreItemNum { get; set; }

        [StringLength(1)]
        [Display(Name ="PreSubItem Number")]
        public string PreSubItem { get; set; }

        [Display(Name ="Reason of Change")]
        public string ReasonOfChange { get; set; }

        public string Comments { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] SSMA_TimeStamp { get; set; }

        public virtual tblEMPLOYEELIST tblEMPLOYEELIST { get; set; }

        public virtual tblEmploymentType tblEmploymentType { get; set; }

        public virtual tblPayPeriod tblPayPeriod { get; set; }

        public virtual tblPOSITIONBUDGETED tblPOSITIONBUDGETED { get; set; }

        public virtual tblStep tblStep { get; set; }
    }
}
