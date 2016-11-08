namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblFunction")]
    public partial class tblFunction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblFunction()
        {
            tblPOSITIONBUDGETEDs = new HashSet<tblPOSITIONBUDGETED>();
        }

        [Key]
        [StringLength(1)]
        public string FuncCode { get; set; }

        [StringLength(25)]
        [Display(Name ="Function")]
        public string FuncDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPOSITIONBUDGETED> tblPOSITIONBUDGETEDs { get; set; }
    }
}
