using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace marvel_API_project.src.Entities
{
    public class Hero
    {
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
