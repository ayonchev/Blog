using System.ComponentModel.DataAnnotations;

namespace Blog.App.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}