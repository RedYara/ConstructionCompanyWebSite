using AutoMapper;
using Diploma.Application.Interfaces;
using Diploma.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.Product.EditProduct
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        private readonly IMapper _mapper;

        public EditProductCommandHandler(IDiplomaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

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
