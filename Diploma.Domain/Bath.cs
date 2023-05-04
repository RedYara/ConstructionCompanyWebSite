namespace Diploma.Domain
{
    public class Bath
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Photos { get; set; }
        public string Desciption { get; set; }
        public int Square { get; set; }
        public string Size { get; set; }
        public int Floors { get; set; }
    }
}
