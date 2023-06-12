using MediatR;

namespace Diploma.Application.CQRS.Commands.Product.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
