using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Queries.Products.GetProductDetailsQuery
{
    public class GetProductDetailsQueryHandler(IWebDbContext dbContext, IMapper mapper) : IRequestHandler<GetProductDetailsQuery, ProductDetailsVm>
    {
        private readonly IWebDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

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
