namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPayLocation")]
    public partial class tblPayLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPayLocation()
        {
            tblEMPLOYEELISTs = new HashSet<tblEMPLOYEELIST>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name ="Pay Location Code")]
        public string PayLocCode { get; set; }

        [StringLength(50)]
        [Display(Name ="Pay Location")]
        public string PayLocDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEMPLOYEELIST> tblEMPLOYEELISTs { get; set; }
    }
}
