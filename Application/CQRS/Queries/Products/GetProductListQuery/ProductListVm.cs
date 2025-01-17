namespace Application.CQRS.Queries.Products.GetProductListQuery
{
    public class ProductListVm
    {
        public ProductListVm()
        {
            Products = [];
        }

        public List<ProductListDto> Products { get; set; }
    }
}
