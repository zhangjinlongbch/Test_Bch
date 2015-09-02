using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BCH_MVC.Models
{
    public class Comment
    {
        [Required]
        [Display(Name = "内容")]
        public string Content { get; set; }
        [Required]
        [Display(Name = "时间")]
        public DateTime CurrentTime { get; set; }
    }
}