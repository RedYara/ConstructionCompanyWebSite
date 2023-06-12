using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Application.CQRS.Queries.Buildings.GetBuildingsListQuery
{
    public class GetBuildingsListQueryHandler : IRequestHandler<GetBuildingsListQuery, BuildingListVm>
    {
        private readonly IDiplomaDbContext _dbContext;
        public GetBuildingsListQueryHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BuildingListVm> Handle(GetBuildingsListQuery request, CancellationToken cancellationToken)
        {
            var buildings = _dbContext.Buildings;
            var buildingList = new BuildingListVm
            {
                Buildings = await buildings.Select(x => new BuildingListDto
                {
                    Desciption = x.Desciption.Substring(0, 100),
                    Floors = x.Floors,
                    Name = x.Name,
                    Photos = x.Photos,
                    Id = x.Id,
                    Preview = x.Preview,
                    Size = x.Size,
                    Square = x.Square,
                    GroupType = x.GroupType,
                    CreateTime = x.CreateTime,
                }).OrderByDescending(x => x.CreateTime)
                .ToListAsync()
        };
            var reviewsList = await _dbContext.Reviews.Take(4).OrderByDescending(x => x.Date).ToListAsync();
            buildingList.Reviews = reviewsList;
            return buildingList;
        }
    }
}
