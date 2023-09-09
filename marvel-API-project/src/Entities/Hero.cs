namespace marvel_API_project.src.Entities
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? GroupId { get; set; }
        public Group group { get; set; }
    }
}
