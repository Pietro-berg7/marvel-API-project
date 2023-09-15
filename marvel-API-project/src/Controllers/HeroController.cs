using marvel_API_project.src.Database;
using marvel_API_project.src.Dto;
using marvel_API_project.src.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marvel_API_project.src.Controllers
{
    [ApiController]
    [Route("api/v1/heros")]
    public class HeroController: ControllerBase
    {
        private readonly DataContext _context;

        public HeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hero>>> List()
        {
            var heroes = await _context.Heroes
                .Include(x => x.group)
                .ToListAsync();

            return heroes;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Hero>> GetById(int id)
        {
            var result = await _context.Heroes
                .Include(x => x.group)
                .FirstOrDefaultAsync(h => h.Id == id);

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

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Hero>> Update(int id, [FromBody] UpdateHero hero)
        {
            var result = await _context.Heroes.SingleOrDefaultAsync(h => h.Id == id);

            if (result != null)
            {
                result.Name = hero.Name;
                result.RealName = hero.RealName;
                result.GroupId = hero.GroupId;
                await _context.SaveChangesAsync();
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var result = await _context.Heroes.SingleOrDefaultAsync(h => h.Id == id);

            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return Ok("hero deleted");
            }
            else
            {
                return BadRequest("hero not found");
            }
        }

        [HttpGet("groups/{id:int}")]
        public async Task<ActionResult<List<Group>>> Groups(int id)
        {
            var heroes = await _context.Heroes
            .Include(x => x.group)
            .Where(x => x.GroupId == id)
            .ToListAsync();

            return Ok(heroes);
        }
    }
}
