namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblGender")]
    public partial class tblGender
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblGender()
        {
            tblEMPLOYEELISTs = new HashSet<tblEMPLOYEELIST>();
        }

        [Key]
        [StringLength(1)]
        [Display(Name ="Gender Code")]
        public string GenderCode { get; set; }

        [StringLength(25)]
        [Display(Name ="Gender")]
        public string GenderDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEMPLOYEELIST> tblEMPLOYEELISTs { get; set; }
    }
}
