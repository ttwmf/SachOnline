namespace SachOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DONDATHANGs = new HashSet<DONDATHANG>();
        }

        [Key]
        [Required]
        public int MaKH { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống.")]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Tài khoản đăng nhập từ 5 - 15 ký tự.")]
        public string TaiKhoan { get; set; }
        

        [Required( ErrorMessage ="Mật khẩu không được để trống.")]
        [StringLength(15, MinimumLength = 6, ErrorMessage ="Mật khẩu phải từ 6 đến 15 ký tự.")]
        public string MatKhau { get; set; }

        [StringLength(50)]
        [Required (ErrorMessage ="Email không được để trống.")]
        [EmailAddress (ErrorMessage = "Email không đúng định dạng.")]
        public string Email { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage ="Số điện thoại không hợp lệ.")]
        public string DienThoai { get; set; }


        [Column(TypeName = "smalldatetime")]
        [Required (ErrorMessage = "Ngày sinh không được để trống.")]
        public DateTime? NgaySinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONDATHANG> DONDATHANGs { get; set; }
    }
}
