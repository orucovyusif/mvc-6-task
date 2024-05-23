using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc__bilet_5.Models
{
	public class Designs 
	{
		public int Id { get; set; }
		[MaxLength(15)]
		public string Name { get; set; }
        [MaxLength(15)]

        public string Description { get; set; }
		public string? ImgUrl { get; set; }
		[NotMapped]
		public IFormFile ImgFile { get; set; }
	}
}
