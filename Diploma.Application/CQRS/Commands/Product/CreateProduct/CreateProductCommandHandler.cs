using AutoMapper;
using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IDiplomaDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IDiplomaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

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
            };


            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
