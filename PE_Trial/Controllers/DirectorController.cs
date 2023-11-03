using AutoMapper;
using DataAccess.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE_Trial.DTOs;
using PE_Trial.Models;

namespace PE_Trial.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DirectorController : ControllerBase
	{
		private readonly PePrnFall22B1Context _context;
		private readonly IMapper mapper;

		public DirectorController(PePrnFall22B1Context context, IMapper mapper)
		{
			_context = context;
			this.mapper = mapper;
		}

		[HttpGet("GetDirectors/{nationality}/{gender}")]
		/*public IActionResult GetDirectors(string nationality, string gender)
		{
			var res = _context.Directors.Where(p => p.Nationality.ToLower() == nationality.ToLower() && p.Male == gender.ToLower().Equals("male")).ToList();
			if( res == null) 
			{ 
				return NotFound();
			}
			var result = res.Select(p => new DirectorDto()
			{
				Id = p.Id,
				FullName = p.FullName,
				Gender = p.Male? "Male" : "Female",
				Dob = p.Dob,
				DobString = p.Dob.ToString("dd/MM/yyyy"),
				Nationality = p.Nationality,
				Description = p.Description
			});
			return Ok(result);
		}*/

		public IActionResult GetDirectors(string nationality, string gender)
		{
			var res = _context.Directors.Where(p => p.Nationality.ToLower() == nationality.ToLower() && p.Male == gender.ToLower().Equals("male")).ToList();
			if (res == null)
			{
				return NotFound();
			}
			var result = mapper.Map<List<DirectorDto>>(res);
			return Ok(result);
		}

		[HttpGet("GetDirector/{id}")]
		/*		public IActionResult GetDirectorById(int id)
				{
					var res = _context.Directors.Include(p => p.Movies).ThenInclude(p => p.Producer).FirstOrDefault(p => p.Id == id);
					if (res == null)
					{
						return NotFound();
					}
					var result = new DirectorDto2()
					{
						Id = res.Id,
						FullName = res.FullName,
						Gender = res.Male ? "Male" : "Female",
						Dob = res.Dob,
						DobString = res.Dob.ToString("dd/MM/yyyy"),
						Nationality = res.Nationality,
						Description = res.Description,
						Movies = res.Movies.Select(p => new MovieDTO() 
						{ 
							Id = p.Id,
							Title = p.Title,
							ReleaseDate = p.ReleaseDate,
							ReleaseYear = p.ReleaseDate.Value.Year,
							Description = p.Description,
							Language = p.Language,
							ProducerId = p.ProducerId,
							DirectorId = p.DirectorId,
							ProducerName = p.Producer.Name,
							DirectorName = p.Director.FullName,
							Genres = p.Genres,
							Stars = p.Stars
						}).ToList(),
					};
					return Ok(result);
				}*/
		public IActionResult GetDirectorById(int id)
		{
			var res = _context.Directors.Include(p => p.Movies).ThenInclude(p => p.Producer).FirstOrDefault(p => p.Id == id);
			if (res == null)
			{
				return NotFound();
			}
			var result = mapper.Map<DirectorDto2>(res);
			return Ok(result);
		}

		[HttpPost("Create")]
		/*public IActionResult CreateProduct(AddRequest addRequest)
		{
			try
			{
				var director = new Director()
				{
					FullName = addRequest.FullName,
					Male = addRequest.Male,
					Dob = Convert.ToDateTime(addRequest.Dob),
					Nationality = addRequest.Nationality,
					Description = addRequest.Description
				};
				_context.Directors.Add(director);
				var row = _context.SaveChanges();
				return Ok(row);
			}
			catch (Exception ex)
			{
				return Conflict("Error");
			}
		}*/
		public IActionResult CreateProduct(AddRequest addRequest)
		{
			try
			{
				var director = mapper.Map<Director>(addRequest);
				_context.Directors.Add(director);
				var row = _context.SaveChanges();
				return Ok(row);
			}
			catch (Exception ex)
			{
				return Conflict("Error");
			}
		}
	}
}
