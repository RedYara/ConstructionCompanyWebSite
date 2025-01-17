using MediatR;

namespace Application.CQRS.Queries.Orders.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<OrderDetailsVm>
    {
        public int Id { get; set; }
    }
}
