using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopK6.Models
{
    /// <summary>
    /// model nay se cho phe p hien thi o ngoai
    /// </summary>
    public class KhachHangView
    {
        [Display(Name = "Họ tên")]
        [MaxLength(150)]
        [Required(ErrorMessage ="*")]
        public string HoTen { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "*")]
        [Remote(controller:"KhachHang", action:"CheckEmailAvaible", ErrorMessage = "Eamil đã tồn tại")]
        public string Email { get; set; }//duy nhat
        [MaxLength(150)]
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "*")]
        public string DienThoai { get; set; }
        [MaxLength(150)]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*")]
        public string MatKhau { get; set; }
        
        [MaxLength(150)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
    }

    [Table("KhachHang")]
    public class KhachHang : KhachHangView
    {
        [Key]
        [MaxLength(50)]
        public string MaKh { get; set; }
        [MaxLength(10)]
        public string RandomKey { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
    }
}
