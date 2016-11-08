namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblVacant")]
    public partial class tblVacant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VacantCode { get; set; }

        [StringLength(25)]
        [Display(Name ="Vacant")]
        public string VacantDesc { get; set; }
    }
}
