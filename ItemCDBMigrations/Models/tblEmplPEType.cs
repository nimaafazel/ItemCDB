namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblEmplPEType")]
    public partial class tblEmplPEType
    {
        [Key]
        [StringLength(1)]
        public string EmplPETypeCode { get; set; }

        [StringLength(15)]
        public string EmplPETypeDesc { get; set; }
    }
}
