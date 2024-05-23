using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Bloger.ViewModels;

public class MemberRegisterVm
{
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; }
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string RepeatPassword { get; set; }
}
