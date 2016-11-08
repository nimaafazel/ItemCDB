namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblEthnicity")]
    public partial class tblEthnicity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEthnicity()
        {
            tblEMPLOYEELISTs = new HashSet<tblEMPLOYEELIST>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Ethnicity Code")]
        public int EthnicCode { get; set; }

        [StringLength(25)]
        [Display(Name ="Ethnicity")]
        public string EthnicDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEMPLOYEELIST> tblEMPLOYEELISTs { get; set; }
    }
}
