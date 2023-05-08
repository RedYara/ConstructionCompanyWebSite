using MediatR;

namespace Diploma.Application.CQRS.Commands.Order.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid BuildingId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
