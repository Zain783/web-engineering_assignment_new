using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication1.data;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private static List<HallBooking> hallBookings = new List<HallBooking>
		{
			new HallBooking {  HallId = 1, HallName = "My Hall ", Location = "Sialkot" },
			new HallBooking {  HallId = 2, HallName = "Grand Palace ", Location = "Sialkot" },
		};

		[HttpGet]
		public IActionResult GetAllBookings()
		{
			return Ok(hallBookings);
		}

		[HttpGet("{id}")]
		public IActionResult GetBookingById(int id)
		{
			var booking = hallBookings.Find(b => b.HallId == id);
			if (booking == null)
			{
				return NotFound();
			}

			return Ok(booking);
		}

		[HttpPost]
		public IActionResult AddBooking([FromBody] HallBooking newBooking)
		{
			newBooking.HallId = hallBookings.Count + 1;

			hallBookings.Add(newBooking);

			return CreatedAtAction(nameof(GetBookingById), new { id = newBooking.HallId }, newBooking);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateBooking(int id, [FromBody] HallBooking updatedBooking)
		{
			var existingBooking = hallBookings.Find(b => b.HallId == id);
			if (existingBooking == null)
			{
				return NotFound();
			}

			// Update the properties of the existing booking
			existingBooking.HallId = updatedBooking.HallId;
			existingBooking.HallName = updatedBooking.HallName;
			existingBooking.Location = updatedBooking.Location;

			return Ok(existingBooking);
		}
	}
}
