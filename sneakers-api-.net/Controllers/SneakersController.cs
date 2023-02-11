using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sneakers_api_.net.models;
using System.Text;
using sneakers_api_.net.data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sneakers_api_.net.Controllers
{
	[Route("[controller]")]
	[ApiController]

	public class SneakersController : ControllerBase
	{
		private readonly HttpClient _httpClient;

		//public SneakersController(HttpClient httpClient)
		//{
		//	_httpClient = httpClient;
		//	_httpClient.BaseAddress = new System.Uri("https://sneakersxu.azurewebsites.net/");
		//}

		private readonly ApiDbContext _context;

		public SneakersController(ApiDbContext context, HttpClient httpClient)
		{
			_context = context;
			_httpClient = httpClient;
			_httpClient.BaseAddress = new System.Uri("https://sneakersxu.azurewebsites.net/");
		}
		// GET: api/<SneakersController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			//var response = await _httpClient.GetAsync("sneakers");

			//if (response.IsSuccessStatusCode)
			//{
			//	await sneakerList.FetchAllSneakers();
			//	var sneakers = sneakerList.GetAllSneakers();

			//	foreach (var sneaker in sneakers)
			//	{
			//		var existingSneaker = _context.Sneakers.Find(sneaker.id);
			//		if (existingSneaker == null)
			//		{
			//			_context.Sneakers.Add(sneaker);
			//			await _context.SaveChangesAsync();

			//		}
			//	}



			//	return Ok(sneakers);
			//}
			//else
			//{
			//	return StatusCode(500, "Request to external API failed with status code: " + response.StatusCode);
			//}
			var Sizes = await _context.Size.ToListAsync();
			var Colors = await _context.Color.ToListAsync();
			var Images = await _context.ImageUrl.ToListAsync();
			var sneakers = await _context.Sneakers.ToListAsync();

			return Ok(sneakers);
		}

		// POST api/<SneakersController>
		[HttpPost]
		public async Task<IActionResult> Post(Sneaker sneaker/*,Sneakers _sneakers*/)
		{
			//var allSneakers = _sneakers.GetAllSneakers();
			//var existingSneaker = allSneakers.Find(s => s.id == sneaker.id && s.brand == sneaker.brand && s.model == sneaker.model);
			//if (existingSneaker == null)
			//{
				var json = JsonConvert.SerializeObject(sneaker);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await _httpClient.PostAsync("http://localhost:3000/", content);
				if (response.IsSuccessStatusCode)
				{
					return Ok();
				}
				return BadRequest();
			//}
			//return BadRequest("the id of the sneakers have to be unique");
		}

		// DELETE api/<SneakersController>/5
		[HttpDelete ]
		public async Task<IActionResult> Delete(Sneaker sneaker, Sneakers _sneakers)
		{
			var allSneakers = _sneakers.GetAllSneakers();
			var existingSneaker = allSneakers.Find(s => s.id == sneaker.id && s.brand == sneaker.brand && s.model == sneaker.model);
			if ( existingSneaker != null)
			{
				var json = JsonConvert.SerializeObject(sneaker);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await _httpClient.PostAsync("https://sneakersxu.azurewebsites.net/deleteSneakerXu", content);
				if (response.IsSuccessStatusCode)
				{
					return Ok();
				}
				return BadRequest();
			}
			return BadRequest("The object that you request doesn't exist");
		}
	}
}
