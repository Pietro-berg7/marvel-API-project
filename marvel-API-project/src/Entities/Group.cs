using System.ComponentModel.DataAnnotations;

namespace marvel_API_project.src.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(80)]
        [Required]
        public string Name { get; set; }
    }
}
