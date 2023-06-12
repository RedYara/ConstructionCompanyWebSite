namespace Diploma.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Preview { get; set; }
        public string Description { get; set; }
        public GroupType GroupType { get; set; }
        public int Price { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
