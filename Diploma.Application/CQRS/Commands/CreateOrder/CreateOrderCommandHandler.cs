using Diploma.Application.Interfaces;
using Diploma.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IDiplomaDbContext _dbContext;

        public CreateOrderCommandHandler (IDiplomaDbContext dbContext) => _dbContext = dbContext;
        public async Task<Guid> Handle (CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CreationDate = DateTime.Now,
                Description = request.Description,
                EditDate = DateTime.Now,
                Title = request.Title,
                UserId = request.UserId,
            };
            await _dbContext.Orders.AddAsync(order, cancellationToken);

            return Guid.NewGuid();

        }
    }
}
