namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPERating")]
    public partial class tblPERating
    {
        [Key]
        public int PERating { get; set; }

        [StringLength(50)]
        public string RatingDescription { get; set; }
    }
}
