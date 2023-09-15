using marvel_API_project.src.Database;
using marvel_API_project.src.Dto;
using marvel_API_project.src.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marvel_API_project.src.Controllers
{
    [ApiController]
    [Route("api/v1/heros")]
    public class HeroController
    {
        private readonly DataContext _context;

        public HeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hero>>> List()
        {
            var heroes = await _context.Heroes.ToListAsync();

            return heroes;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Hero>> GetById(int id)
        {
            var result = await _context.Heroes.FirstOrDefaultAsync(h => h.Id == id);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Hero>> Create([FromBody] CreateHero hero)
        {
            var newHero = new Hero(hero);

            _context.Heroes.Add(newHero);
            await _context.SaveChangesAsync();

            return newHero;
        }
    }
}
