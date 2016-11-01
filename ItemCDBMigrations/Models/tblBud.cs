namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblBud")]
    public partial class tblBud
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblBud()
        {
            tblPOSITIONBUDGETEDs = new HashSet<tblPOSITIONBUDGETED>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BudCode { get; set; }

        [StringLength(50)]
        public string BudDesc { get; set; }

        [StringLength(50)]
        public string BudDesc1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPOSITIONBUDGETED> tblPOSITIONBUDGETEDs { get; set; }
    }
}
