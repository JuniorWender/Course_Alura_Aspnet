using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Section;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SectionController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public SectionController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSection (CreateSectionDto sectionDto)
        {
            Section section = _mapper.Map<Section>(sectionDto);
            _context.Sections.Add(section);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSection), new { Id = section.Id }, section);
        }

        [HttpGet("{id}")]
        public IActionResult GetSection(int id)
        {
            Section section = _context.Sections.FirstOrDefault(x => x.Id == id);

            if (section != null)
            {
                ReadSectionDto sectionDto = _mapper.Map<ReadSectionDto>(section);

                return Ok(sectionDto);
            }
            return NotFound();
        }
    }
}
