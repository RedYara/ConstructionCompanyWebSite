using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Application.CQRS.Commands.Order.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        public DeleteOrderCommandHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);
            _dbContext.Orders.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
