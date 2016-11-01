namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblPEStatu
    {
        [Key]
        public int PerfEvalID { get; set; }

        public int? EmpID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DueDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? RatingFromDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? RatingToDate { get; set; }

        [StringLength(15)]
        public string ReportType { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ApprovedByDivChiefDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ApprovedBySecHeadDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ApprovedByEmployeeDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? HRCompletedDate { get; set; }

        [StringLength(15)]
        public string PEStatus { get; set; }

        public int? Rating { get; set; }

        public int? ActPosID { get; set; }

        public int? DivCode { get; set; }

        public int? Section { get; set; }

        public int? Unit { get; set; }

        [StringLength(50)]
        public string Item { get; set; }

        [StringLength(5)]
        public string SubItem { get; set; }

        [StringLength(50)]
        public string Step { get; set; }

        public string Comments { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? PECreationDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? PELastChangedDate { get; set; }

        [StringLength(10)]
        public string PERecordChangedBy { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] SSMA_TimeStamp { get; set; }
    }
}
