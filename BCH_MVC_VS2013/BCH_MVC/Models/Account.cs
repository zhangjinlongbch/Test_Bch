using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BCH_MVC.Models
{
    //登陆时的账户MODEL
    public class AccountLogin
    {
        [Display(Name ="手机号")]
        public string UserId { get; set; }
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }
    }
    //注册时的账户MODEL
    public class AccountRegister
    {
        [Required]
        [Display(Name = "手机号")]
        public string UserId {get; set; }
        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 3)]
        public string Pwd { get; set; }
        [Required]
        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Compare("Pwd", ErrorMessage = "新密码和确认密码不匹配。")]
        public string Pwd_Confirm { get; set; }
    }
}