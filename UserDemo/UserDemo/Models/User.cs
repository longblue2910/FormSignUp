using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserDemo.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Hãy nhập họ tên...")]
        [Display(Name = "Họ và tên")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Hãy nhập email...")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Hãy nhập đúng định dạng email !")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Hãy nhập Số điện thoại...")]
        [Display(Name = "Số điện thoại")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Nhập số điện thoại đúng định dạng, số điện thoại gồm 10 số")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Hãy nhập mật khẩu...")]
        [Display(Name = "Mật khẩu")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,20}$", ErrorMessage ="Sử dụng 6 ký tự trở lên và kết hợp chữ cái gồm chữ in hoa, in thường và chữ số")]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }
        [Required(ErrorMessage = "Mật khẩu không khớp...")]
        [Display(Name = "Nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Pwd", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPwd { get; set; }
        [Required(ErrorMessage = "Trường này không được để trông !")]
        [Display(Name = "Tỉnh thành")]
        public string Province { get; set; }
        [Required(ErrorMessage = "Trường này không được để trông !")]
        [Display(Name = "Quận/huyện")]
        public string District { get; set; }
        [Required(ErrorMessage = "Trường này không được để trông !")]
        [Display(Name = "Phường/xã")]
        public string Wards { get; set; }
        [Required(ErrorMessage = "Trường này không được để trông !")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
    }
}
