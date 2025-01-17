namespace Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid BuildingId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }
}
