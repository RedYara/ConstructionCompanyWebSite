using MediatR;

namespace Diploma.Application.CQRS.Commands.Order.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
