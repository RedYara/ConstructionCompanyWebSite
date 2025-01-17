using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler(IWebDbContext dbContext) : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            using MemoryStream previewMs = new();
            request.Preview.CopyTo(previewMs);
            var fileBytesPreview = previewMs.ToArray();
            var previewIconBase64 = Convert.ToBase64String(fileBytesPreview);


            var product = new Domain.Product()
            {
                Description = request.Description,
                GroupType = await _dbContext.GroupTypes.FirstOrDefaultAsync(x => x.Id == request.GroupTypeId),
                Name = request.Name,
                Preview = previewIconBase64,
                Price = request.Price,
                CreateTime = DateTime.Now
            };


            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
