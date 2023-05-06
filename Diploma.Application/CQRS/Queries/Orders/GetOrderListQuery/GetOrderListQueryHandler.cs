using AutoMapper;
using AutoMapper.QueryableExtensions;
using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Application.CQRS.Queries.Orders.GetOrderListQuery
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, OrderListVm>
    {
        private readonly IDiplomaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IDiplomaDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<OrderListVm> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _dbContext.Orders
                .ProjectTo<OrderListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderListVm { Orders = orderList };

        }
    }
}
