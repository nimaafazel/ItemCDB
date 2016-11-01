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

        public int ActPosNum { get; set; }

        public int EmplID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EffectiveDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DeptHireDate { get; set; }

        [Required]
        [StringLength(1)]
        public string ActEmplStatus { get; set; }

        [Required]
        [StringLength(10)]
        public string ActItemNum { get; set; }

        [Required]
        [StringLength(1)]
        public string ActSubItem { get; set; }

        [StringLength(50)]
        public string Step { get; set; }

        [Column(TypeName = "money")]
        public decimal? PayRate { get; set; }

        public int? PayPeriod { get; set; }

        [Required]
        [StringLength(1)]
        public string EmplType { get; set; }

        [StringLength(10)]
        public string PreItemNum { get; set; }

        [StringLength(1)]
        public string PreSubItem { get; set; }

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
