using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.Product.EditProduct
{
    public class EditProductCommandHandler(IWebDbContext dbContext, IMapper mapper) : IRequestHandler<EditProductCommand, bool>
    {
        private readonly IWebDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<bool> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FindAsync(request.Id);

            // Update the properties of the product entity with the values from the command
            if (request.Name != null)
                product.Name = request.Name;

            if (request.Description != null)
                product.Description = request.Description;

            if (request.Price != default)
                product.Price = request.Price;

            product.GroupType = product.GroupType = await _dbContext.GroupTypes.FirstOrDefaultAsync(x => x.Id == request.GroupTypeId);

            if (request.GroupTypeId != product.GroupType.Id)
                product.GroupType = await _dbContext.GroupTypes.FirstOrDefaultAsync(x => x.Id == request.GroupTypeId);


            if (request.Preview != null)
            {
                using MemoryStream previewMs = new();
                request.Preview.CopyTo(previewMs);
                var fileBytesPreview = previewMs.ToArray();
                var previewIconBase64 = Convert.ToBase64String(fileBytesPreview);
                product.Preview = previewIconBase64;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
