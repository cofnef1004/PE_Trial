using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE_Trial_2.Dtos;
using PE_Trial_2.Models;

namespace PE_Trial_2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private PrnSum22B1Context context;

		public OrderController(PrnSum22B1Context context)
		{
			this.context = context;
		}

		[HttpGet("GetAllOrder")]
		public IActionResult Get()
		{
			var res = context.Orders.Include(p => p.Customer).Include(p => p.Employee).ThenInclude(p => p.Department).ToList();
			if (res == null)
			{
				return BadRequest();
			}
			var result = res.Select(p => new OrderDto
			{
				OrderId = p.OrderId,
				CustomerId = p.CustomerId,
				CustomerName = p.Customer.ContactName,
				EmployeeId = p.EmployeeId,
				EmployeeName = p.Employee.FirstName+" "+p.Employee.LastName,
				DepartmentId = p.Employee.Department.DepartmentId,
				DepartmentName = p.Employee.Department.DepartmentName,
				OrderDate = p.OrderDate,
				RequiredDate = p.RequiredDate,
				ShippedDate = p.ShippedDate,
				Freight = p.Freight,
				ShipName = p.ShipName,
				ShipAddress = p.ShipAddress,
				ShipCity = p.ShipCity,
				ShipRegion = p.ShipRegion,
				ShipPostalCode = p.ShipPostalCode,
				ShipCountry = p.ShipCountry
			});
			return Ok(result);
		}

		[HttpGet("GetAllOrderByCustomer/{CustomerId}")]
		public IActionResult Get1(string CustomerId)
		{
			var res = context.Orders.Include(p => p.Customer).Include(p => p.Employee).ThenInclude(p => p.Department).Where(p=>p.CustomerId.ToLower().Contains(CustomerId)).ToList();
			if (res == null)
			{
				return BadRequest();
			}
			var result = res.Select(p => new OrderDto
			{
				OrderId = p.OrderId,
				CustomerId = p.CustomerId,
				CustomerName = p.Customer.ContactName,
				EmployeeId = p.EmployeeId,
				EmployeeName = p.Employee.FirstName + " " + p.Employee.LastName,
				DepartmentId = p.Employee.Department.DepartmentId,
				DepartmentName = p.Employee.Department.DepartmentName,
				OrderDate = p.OrderDate,
				RequiredDate = p.RequiredDate,
				ShippedDate = p.ShippedDate,
				Freight = p.Freight,
				ShipName = p.ShipName,
				ShipAddress = p.ShipAddress,
				ShipCity = p.ShipCity,
				ShipRegion = p.ShipRegion,
				ShipPostalCode = p.ShipPostalCode,
				ShipCountry = p.ShipCountry
			});
			return Ok(result);
		}

		[HttpGet("GetOrderByDate/{from}/{to}")]
		public IActionResult Get2(string from, string to)
		{
			DateTime fromDate;
			DateTime toDate;
			if (!DateTime.TryParse(from, out fromDate) || !DateTime.TryParse(to, out toDate))
			{
				return BadRequest("Invalid date format.");
			}
			var orders = context.Orders
				.Include(p => p.Customer)
				.Include(p => p.Employee)
					.ThenInclude(p => p.Department)
				.Where(p => p.OrderDate >= fromDate && p.OrderDate <= toDate)
				.ToList();
			if (orders == null)
			{
				return BadRequest();
			}
			var result = orders.Select(p => new OrderDto
			{
				OrderId = p.OrderId,
				CustomerId = p.CustomerId,
				CustomerName = p.Customer.ContactName,
				EmployeeId = p.EmployeeId,
				EmployeeName = p.Employee.FirstName + " " + p.Employee.LastName,
				DepartmentId = p.Employee.Department.DepartmentId,
				DepartmentName = p.Employee.Department.DepartmentName,
				OrderDate = p.OrderDate,
				RequiredDate = p.RequiredDate,
				ShippedDate = p.ShippedDate,
				Freight = p.Freight,
				ShipName = p.ShipName,
				ShipAddress = p.ShipAddress,
				ShipCity = p.ShipCity,
				ShipRegion = p.ShipRegion,
				ShipPostalCode = p.ShipPostalCode,
				ShipCountry = p.ShipCountry
			});

			return Ok(result);
		}
	}
}

