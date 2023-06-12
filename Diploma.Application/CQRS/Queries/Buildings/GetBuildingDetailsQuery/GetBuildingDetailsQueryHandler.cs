using AutoMapper;
using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Application.CQRS.Queries.Buildings.GetBuildingDetailsQuery
{
    public class GetBuildingDetailsQueryHandler : IRequestHandler<GetBuildingDetailsQuery, BuildingDetailsVm>
    {
        private readonly IDiplomaDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBuildingDetailsQueryHandler(IDiplomaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BuildingDetailsVm> Handle(GetBuildingDetailsQuery request, CancellationToken cancellationToken)
        {
            var building = await _dbContext.Buildings.Include(x => x.Comments).Include(x => x.GroupType).FirstOrDefaultAsync(x => x.Id == request.Id);


            return _mapper.Map<BuildingDetailsVm>(building);
        }
    }
}
