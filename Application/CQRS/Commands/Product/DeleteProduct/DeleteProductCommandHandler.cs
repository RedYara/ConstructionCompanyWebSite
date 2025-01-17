using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandHandler(IWebDbContext dbContext) : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
