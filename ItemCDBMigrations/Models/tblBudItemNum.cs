namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblBudItemNum")]
    public partial class tblBudItemNum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblBudItemNum()
        {
            tblPOSITIONBUDGETEDs = new HashSet<tblPOSITIONBUDGETED>();
        }

        [Key]
        [StringLength(10)]
        public string BudItemNum { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Item Description")]
        public string BudItemDesc { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name ="Budgeted Schedule")]
        public string BudSchedule { get; set; }

        [StringLength(255)]
        [Display(Name ="Budegeted Note")]
        public string BudNote { get; set; }

        public int? BudBargainUnit { get; set; }

        public virtual tblBargainUnit tblBargainUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPOSITIONBUDGETED> tblPOSITIONBUDGETEDs { get; set; }
    }
}
