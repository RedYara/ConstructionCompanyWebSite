using MediatR;

namespace Diploma.Application.CQRS.Queries.GetOrderListQuery
{
    public class GetOrderListQuery : IRequest<OrderListVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
