using MediatR;

namespace Diploma.Application.CQRS.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<OrderDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
