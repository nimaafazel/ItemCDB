namespace ItemCDBMigrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDivision")]
    public partial class tblDivision
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDivision()
        {
            tblPOSITIONBUDGETEDs = new HashSet<tblPOSITIONBUDGETED>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DivCode { get; set; }

        [StringLength(50)]
        public string DivDesc { get; set; }

        [StringLength(50)]
        public string DivDesc1 { get; set; }

        [StringLength(50)]
        public string DivChief { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPOSITIONBUDGETED> tblPOSITIONBUDGETEDs { get; set; }
    }
}
