namespace Data
{
    public class TicketStatusDTO : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TicketStatusDTO(string name)
        {
            Name = name;
        }
    }
}
