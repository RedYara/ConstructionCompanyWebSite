using AutoMapper;
using Diploma.Application.CQRS.Queries.Orders.GetOrderDetails;
using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Application.CQRS.Queries.Houses.GetHouseDetailsQuery
{
    public class GetHouseDetailsQueryHandler : IRequestHandler<GetHouseDetailsQuery, HouseDetailsVm>
    {
        private readonly IDiplomaDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetHouseDetailsQueryHandler(IDiplomaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<HouseDetailsVm> Handle (GetHouseDetailsQuery request, CancellationToken cancellationToken)
        {
            var house = await _dbContext.Houses.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == request.Id);
            

            return _mapper.Map<HouseDetailsVm>(house);
        }
    }
}
