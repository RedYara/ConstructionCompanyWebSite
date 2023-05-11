namespace Diploma.Domain
{
    public class Bath
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Photos { get; set; }
        public string Preview { get; set; }
        public string Desciption { get; set; }
        public string Square { get; set; }
        public List<Comment> Comments { get; set; }
        public string Size { get; set; }
        public int Floors { get; set; }
    }
}
