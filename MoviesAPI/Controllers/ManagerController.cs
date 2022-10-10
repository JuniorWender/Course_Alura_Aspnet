using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Manager;
using MoviesAPI.Data.Dtos.Movie;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ManagerController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public ManagerController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult AddManager(CreateManagerDto managerDto)
        {
            Manager manager = _mapper.Map<Manager>(managerDto);
            _context.Managers.Add(manager);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetManager), new { Id = manager.Id }, manager);
        }

        public IActionResult GetManager(int id)
        {
            Manager manager = _context.Managers.FirstOrDefault(manager => manager.Id == id);

            if (manager != null)
            {
                ReadManagerDto managerDto = _mapper.Map<ReadManagerDto>(manager);

                return Ok(managerDto);
            }
            return NotFound();
        }
    }
}
