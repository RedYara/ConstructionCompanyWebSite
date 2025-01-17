using MediatR;

namespace Application.CQRS.Commands.Order.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
