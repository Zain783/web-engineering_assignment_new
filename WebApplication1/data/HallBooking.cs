using System.ComponentModel.DataAnnotations;

namespace WebApplication1.data
{
	public class HallBooking
	{
		[Key]
		public int HallId { get; set; }

		[Required]
		public string HallName { get; set; }

		[Required]
		public string Location { get; set; }
	}
}
