using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Queries.Orders.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsVm>
    {
        private readonly IWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler(IWebDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<OrderDetailsVm> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);

            return _mapper.Map<OrderDetailsVm>(entity);

        }
    }
}
