using MediatR;

namespace Application.CQRS.Queries.Products.GetProductListQuery
{
    public class GetProductListQuery : IRequest<ProductListVm>
    {
    }
}
