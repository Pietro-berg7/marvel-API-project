using marvel_API_project.src.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace marvel_API_project.src.Entities
{
    public class Hero
    {
        public Hero()
        {
        }

        public Hero(CreateHero hero)
        {
            Name = hero.Name;
            RealName = hero.RealName;
            GroupId = hero.GroupId;
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(80)]
        [MinLength(3)]
        public string Name { get; set; }

        [MaxLength(80)]
        [Required]
        public string RealName { get; set; }

        public DateTime CreatedAt { get; set; }
        public int? GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group group { get; set; }
    }
}
