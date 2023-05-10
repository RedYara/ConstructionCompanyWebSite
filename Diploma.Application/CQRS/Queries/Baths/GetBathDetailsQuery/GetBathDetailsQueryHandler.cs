using AutoMapper;
using Diploma.Application.CQRS.Queries.Baths.GetBathDetailsQuery;
using Diploma.Application.CQRS.Queries.Orders.GetOrderDetails;
using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Application.CQRS.Queries.Houses.GetHouseDetailsQuery
{
    public class GetBathDetailsQueryHandler : IRequestHandler<GetBathDetailsQuery, BathDetailsVm>
    {
        private readonly IDiplomaDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBathDetailsQueryHandler(IDiplomaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BathDetailsVm> Handle (GetBathDetailsQuery request, CancellationToken cancellationToken)
        {
            var house = await _dbContext.Baths.FirstOrDefaultAsync(x => x.Id == request.Id);

            return _mapper.Map<BathDetailsVm>(house);
        }
    }
}
