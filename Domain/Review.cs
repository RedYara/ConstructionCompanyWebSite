namespace Domain
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
    }
}
