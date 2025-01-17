using MediatR;

namespace Application.CQRS.Queries.Orders.GetOrderListQuery
{
    public class GetOrderListQuery : IRequest<OrderListVm>
    {
        public Guid Id { get; set; }
    }
}
