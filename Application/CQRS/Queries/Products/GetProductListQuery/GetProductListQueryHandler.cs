using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Queries.Products.GetProductListQuery
{
    public class GetProductListQueryHandler(IWebDbContext dbContext) : IRequestHandler<GetProductListQuery, ProductListVm>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<ProductListVm> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = _dbContext.Products;
            var productList = new ProductListVm
            {
                Products = await products.Select(x => new ProductListDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    GroupTypeId = x.GroupType.Id,
                    Preview = x.Preview,
                    CreateTime = x.CreateTime
                }).OrderByDescending(x => x.CreateTime)
                .ToListAsync(cancellationToken)
            };

            return productList;
        }
    }
}
