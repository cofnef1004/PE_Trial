using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PE_Trial_2.Dtos;
using PE_Trial_2.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace PE_Trial2_Client.Controllers
{
	public class OrderController : Controller
	{
		private readonly HttpClient client = null;
		private string OrderApiUrl = "";
		private string CustomerApiUrl = "";

		public OrderController()
		{
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			OrderApiUrl = "http://localhost:5231/api/Order";
			CustomerApiUrl = "http://localhost:5231/api/Customer";
		}

		/*		public async Task<IActionResult> Index(string from, string to)
				{
					string apiUrl = $"{OrderApiUrl}/GetAllOrder";
					if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
					{
						apiUrl = $"{OrderApiUrl}/GetOrderByDate/{from}/{to}";
					}
					HttpResponseMessage response = await client.GetAsync(apiUrl);
					string responseData = await response.Content.ReadAsStringAsync();
					var options = new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true,
					};
					List<OrderDto> orders = System.Text.Json.JsonSerializer.Deserialize<List<OrderDto>>(responseData, options);
					ViewData["order"] = orders;
					return View(orders);
				}*/

		public async Task<List<Customer>> GetCustomers()
		{
			HttpResponseMessage response = await client.GetAsync(CustomerApiUrl);
			string responseData = await response.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
			};
			List<Customer> customers = System.Text.Json.JsonSerializer.Deserialize<List<Customer>>(responseData, options);
			return customers;
		}

		public async Task<IActionResult> Index(string customerId)
		{
			string apiUrl = $"{OrderApiUrl}/GetAllOrder";
			if (!string.IsNullOrEmpty(customerId))
			{
				apiUrl = $"{OrderApiUrl}/GetAllOrderByCustomer/{customerId}";
			}
			HttpResponseMessage response = await client.GetAsync(apiUrl);
			string responseData = await response.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
			};
			List<OrderDto> orders = System.Text.Json.JsonSerializer.Deserialize<List<OrderDto>>(responseData, options);
			List<Customer> customers = await GetCustomers();
			ViewData["customer"] = customers;
			ViewData["order"] = orders;
			return View(orders);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			HttpResponseMessage response = await client.PostAsync($"{CustomerApiUrl}/Delete/{id}", null);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return NotFound();
		}
	}
}
