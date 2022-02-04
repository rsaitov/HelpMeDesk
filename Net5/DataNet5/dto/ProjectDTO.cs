namespace Data
{
    public class ProjectDTO : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProjectDTO(string name)
        {
            Name = name;
        }
    }
}
