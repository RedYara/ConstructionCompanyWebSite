using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.Order.DeleteOrder
{
    public class DeleteOrderCommandHandler(IWebDbContext dbContext) : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);
            _dbContext.Orders.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
