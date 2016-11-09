namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSection")]
    public partial class tblSection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSection()
        {
            tblPOSITIONBUDGETEDs = new HashSet<tblPOSITIONBUDGETED>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SecCode { get; set; }

        [StringLength(50)]
        [Display(Name ="Section")]
        [Required]
        public string SecDesc { get; set; }

        [StringLength(50)]
        [Display(Name ="Section Name")]
        [Required]
        public string SecDesc1 { get; set; }

        [StringLength(50)]
        [Display(Name ="Section Head")]
        public string SecHead { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPOSITIONBUDGETED> tblPOSITIONBUDGETEDs { get; set; }
    }
}
