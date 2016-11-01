namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblEmploymentType")]
    public partial class tblEmploymentType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEmploymentType()
        {
            tblPOSITIONACTUALs = new HashSet<tblPOSITIONACTUAL>();
        }

        [Key]
        [StringLength(1)]
        public string EmplType { get; set; }

        [StringLength(50)]
        public string EmplTypeDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPOSITIONACTUAL> tblPOSITIONACTUALs { get; set; }
    }
}
