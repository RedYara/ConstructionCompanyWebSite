using MediatR;

namespace Diploma.Application.CQRS.Queries.Products.GetProductDetailsQuery
{
    public class GetProductDetailsQuery : IRequest<ProductDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
