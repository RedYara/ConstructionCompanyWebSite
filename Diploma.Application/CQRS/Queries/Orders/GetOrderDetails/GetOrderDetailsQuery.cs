using MediatR;

namespace Diploma.Application.CQRS.Queries.Orders.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<OrderDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
