using MediatR;

namespace Application.CQRS.Commands.Order.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public Guid RowId { get; set; }
        public string rowType { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
