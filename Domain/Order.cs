namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public Guid RowId { get; set; }
        public string RowType { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public OrderType OrderType { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
