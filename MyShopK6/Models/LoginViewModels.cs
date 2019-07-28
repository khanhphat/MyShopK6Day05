using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopK6.Models
{
    public class LoginViewModels
    {
        [MaxLength(150)]
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }//duy nhat

        [MaxLength(150)]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*")]
        public string MatKhau { get; set; }
    }
}
