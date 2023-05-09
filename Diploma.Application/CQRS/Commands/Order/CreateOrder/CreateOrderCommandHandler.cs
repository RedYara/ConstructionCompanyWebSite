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
            var order = new Domain.Order
            {
                CreationDate = DateTime.Now,
                BuildingId = request.BuildingId,
                Name = request.Name,
                Phone = request.Phone,
                BuildingType = request.BuildingType,
            };
            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Guid.NewGuid();

        }
    }
}
