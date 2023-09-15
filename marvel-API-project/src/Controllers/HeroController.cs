using marvel_API_project.src.Database;
using marvel_API_project.src.Dto;
using marvel_API_project.src.Entities;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id:int}")]
        public Hero GetById(int id)
        {
            var result = _context.Heroes.FirstOrDefault(h => h.Id == id);

            return result;
        }

        [HttpPost]
        public Hero Create(CreateHero hero)
        {
            var newHero = new Hero(hero);

            _context.Heroes.Add(newHero);
            _context.SaveChanges();

            return newHero;
        }
    }
}
