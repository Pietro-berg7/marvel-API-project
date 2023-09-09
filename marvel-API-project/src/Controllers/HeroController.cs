using marvel_API_project.src.Dto;
using Microsoft.AspNetCore.Mvc;

namespace marvel_API_project.src.Controllers
{
    [ApiController]
    [Route("api/v1/heros")]
    public class HeroController
    {
        [HttpPost]
        public CreateHero Create(CreateHero hero)
        {
            return hero;
        }
    }
}
