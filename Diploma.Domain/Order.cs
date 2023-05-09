namespace Diploma.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid BuildingId { get; set; }
        public string BuildingType { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
