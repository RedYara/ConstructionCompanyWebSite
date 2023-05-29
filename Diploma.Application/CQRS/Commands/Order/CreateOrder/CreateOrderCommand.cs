using MediatR;

namespace Diploma.Application.CQRS.Commands.Order.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public Guid BuildingId { get; set; }
        public string BuildingType { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
