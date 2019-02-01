using System.ComponentModel.DataAnnotations;

namespace Blog.App.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^([A-Z][a-z]+)\s([A-Z][a-z]+)$")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}