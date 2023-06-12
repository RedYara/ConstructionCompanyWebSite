using AutoMapper;
using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Application.CQRS.Queries.Products.GetProductDetailsQuery
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsVm>
    {
        private readonly IDiplomaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductDetailsQueryHandler(IDiplomaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products
                .Include(p => p.Comments)
                .Include(p => p.GroupType)
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            return _mapper.Map<ProductDetailsVm>(product);
        }
    }
}
