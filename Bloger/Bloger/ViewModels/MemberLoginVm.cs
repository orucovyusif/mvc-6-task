using System.ComponentModel.DataAnnotations;

namespace Bloger.ViewModels;

public class MemberLoginVm
{
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
