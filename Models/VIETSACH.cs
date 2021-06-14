namespace SachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIETSACH")]
    public partial class VIETSACH
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTG { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        [StringLength(30)]
        public string VaiTro { get; set; }

        [StringLength(30)]
        public string ViTri { get; set; }

        public virtual SACH SACH { get; set; }

        public virtual TACGIA TACGIA { get; set; }
    }
}
