namespace ADO_ENTITY_FRAMWORK.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbLop")]
    public partial class tbLop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbLop()
        {
            tbSinhViens = new HashSet<tbSinhVien>();
        }

        [Key]
        [StringLength(10)]
        public string MaLop { get; set; }

        [StringLength(50)]
        public string TenLop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbSinhVien> tbSinhViens { get; set; }
    }
}
