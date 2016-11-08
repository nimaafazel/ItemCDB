namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPayPeriod")]
    public partial class tblPayPeriod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPayPeriod()
        {
            tblPOSITIONACTUALs = new HashSet<tblPOSITIONACTUAL>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PayTypeID { get; set; }

        [StringLength(50)]
        [Display(Name ="Pay Period")]
        public string PayTypeDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPOSITIONACTUAL> tblPOSITIONACTUALs { get; set; }
    }
}
