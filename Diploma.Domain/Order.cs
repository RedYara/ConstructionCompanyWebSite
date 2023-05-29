namespace Diploma.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public Guid BuildingId { get; set; }
        public string BuildingType { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
