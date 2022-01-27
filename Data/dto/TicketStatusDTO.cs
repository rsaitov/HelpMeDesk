namespace Data
{
    public class TicketStatusDTO
    {
        public int Id { get; }
        public string Name { get; }
        public TicketStatusDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
