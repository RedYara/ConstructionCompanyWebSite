using Diploma.Application.Interfaces;
using MediatR;

namespace Diploma.Application.CQRS.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IDiplomaDbContext _dbContext;

        public CreateOrderCommandHandler(IDiplomaDbContext dbContext) => _dbContext = dbContext;
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CreationDate = DateTime.Now,
                Description = request.Description,
                EditDate = DateTime.Now,
                Title = request.Title,
            };
            await _dbContext.Orders.AddAsync(order, cancellationToken);

            return Guid.NewGuid();

        }
    }
}
