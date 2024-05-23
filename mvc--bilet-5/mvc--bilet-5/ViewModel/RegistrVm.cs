using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace mvc__bilet_5.ViewModel
{
    public class RegistrVm
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Surname { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
    }
}
