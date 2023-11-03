using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE_Trial_2.Models;
using System.Net.Http.Headers;
using System.Text;

namespace PE_Trial_2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private PrnSum22B1Context context;

		public CustomerController(PrnSum22B1Context context)
		{
			this.context = context;
		}

		[HttpGet]
		public List<Customer> GetAll()
		{
			return context.Customers.ToList();
		}

		[HttpPost("Delete/{CustomerId}")]
		public IActionResult Delete(string CustomerId)
		{
			try
			{
				var customer = context.Customers
					.Include(c => c.Orders)
						.ThenInclude(o => o.OrderDetails)
					.SingleOrDefault(c => c.CustomerId == CustomerId);
				if (customer == null)
				{
					return NotFound();
				}
				int orderCount = customer.Orders.Count;
				int orderDetailCount = customer.Orders.Sum(o => o.OrderDetails.Count);

				foreach (var order in customer.Orders)
				{
					context.OrderDetails.RemoveRange(order.OrderDetails);
				}
				context.Orders.RemoveRange(customer.Orders);
				context.Customers.Remove(customer);
				context.SaveChanges();

				var response = new
				{
					CustomerDeleted = 1,
					OrderDeleted = orderCount,
					OrderDetailDeleted = orderDetailCount
				};
				return Ok(response);
			}
			catch (Exception ex)
			{
				return Conflict("Error");
			}
		}
	}
}
