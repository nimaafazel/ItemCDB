namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEmplPEStatu
    {
        [Key]
        [StringLength(1)]
        public string EmplPEStatusCode { get; set; }

        [StringLength(20)]
        public string EmplPEStatusDesc { get; set; }
    }
}
