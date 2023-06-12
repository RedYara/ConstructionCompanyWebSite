using MediatR;

namespace Diploma.Application.CQRS.Queries.Products.GetProductListQuery
{
    public class GetProductListQuery : IRequest<ProductListVm>
    {
    }
}
