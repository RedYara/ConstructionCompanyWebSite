using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Application.CQRS.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;

        public DeleteProductCommandHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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
