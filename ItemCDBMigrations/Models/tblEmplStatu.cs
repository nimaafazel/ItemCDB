namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEmplStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEmplStatu()
        {
            tblEMPLOYEELISTs = new HashSet<tblEMPLOYEELIST>();
        }

        [Key]
        [StringLength(1)]
        public string EmplStatusCode { get; set; }

        [StringLength(10)]
        public string EmplStatusDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEMPLOYEELIST> tblEMPLOYEELISTs { get; set; }
    }
}
