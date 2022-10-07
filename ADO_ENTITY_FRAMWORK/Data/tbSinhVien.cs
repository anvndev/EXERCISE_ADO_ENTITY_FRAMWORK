namespace ADO_ENTITY_FRAMWORK.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbSinhVien")]
    public partial class tbSinhVien
    {
        [Key]
        [StringLength(10)]
        public string MaSV { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(10)]
        public string MaLop { get; set; }

        public virtual tbLop tbLop { get; set; }
    }
}
