namespace Diploma.Application.CQRS.Queries.Products.GetProductListQuery
{
    public class ProductListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int GroupTypeId { get; set; }
        public string Preview { get; set; }
        public DateTime CreateTime {
            get; set;
        }
    }
}
