using Microsoft.AspNetCore.Identity;

namespace mvc__bilet_5.Models
{
	public class User : IdentityUser
	{
		public string Name { get; set; }
		public string Surname { get; set; }
	}
}
