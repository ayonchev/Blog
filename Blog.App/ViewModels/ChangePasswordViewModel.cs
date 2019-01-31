using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.App.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [MaxLength(100)]
        public string OldPassword { get; set; }

        [Required]
        [MaxLength(100)]
        public string NewPassword { get; set; }
    }
}
