using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Application.CQRS.Queries.BathsAndHouses
{
    public class GetBathsAndHousesQueryHandler : IRequestHandler<GetBathsAndHousesQuery, BathsAndHousesVm>
    {
        private readonly IDiplomaDbContext _dbContext;
        public GetBathsAndHousesQueryHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BathsAndHousesVm> Handle (GetBathsAndHousesQuery request, CancellationToken cancellationToken)
        {

            var houses = _dbContext.Houses;
            var houseList = new BathsAndHousesVm
            {
                BathsAndHouses = await houses.Select(x => new BathsAndHousesDto
                {
                    Desciption = x.Desciption.Substring(0, 200),
                    Floors = x.Floors,
                    Name = x.Name,
                    Photos = x.Photos,
                    Id = x.Id,
                    BuildingType = "House",
                    Preview = x.Preview,
                    Size = x.Size,
                    Square = x.Square
                }).Take(4).ToListAsync(cancellationToken)
            };
            var baths = _dbContext.Baths;
            var bathList = new BathsAndHousesVm
            {
                BathsAndHouses = await baths.Select(x => new BathsAndHousesDto
                {
                    Desciption = x.Desciption.Substring(0, 200),
                    Floors = x.Floors,
                    Name = x.Name,
                    Photos = x.Photos,
                    Id = x.Id,
                    BuildingType = "Bath",
                    Preview = x.Preview,
                    Size = x.Size,
                    Square = x.Square
                }).Take(4).ToListAsync(cancellationToken)
            };
            foreach (var item in bathList.BathsAndHouses)
            {
                houseList.BathsAndHouses.Add(item);
            }
            return houseList;
        }
    }
}
