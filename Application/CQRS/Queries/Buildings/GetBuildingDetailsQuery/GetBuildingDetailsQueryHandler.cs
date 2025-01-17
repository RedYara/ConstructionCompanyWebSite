using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Queries.Buildings.GetBuildingDetailsQuery
{
    public class GetBuildingDetailsQueryHandler(IWebDbContext dbContext, IMapper mapper) : IRequestHandler<GetBuildingDetailsQuery, BuildingDetailsVm>
    {
        private readonly IWebDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<BuildingDetailsVm> Handle(GetBuildingDetailsQuery request, CancellationToken cancellationToken)
        {
            var building = await _dbContext.Buildings.Include(x => x.Comments).Include(x => x.GroupType).FirstOrDefaultAsync(x => x.Id == request.Id);


            return _mapper.Map<BuildingDetailsVm>(building);
        }
    }
}
