using Diploma.Application.Interfaces;
using Diploma.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.Houses.GetHouseListQuery
{
    public class GetHouseListQueryHandler : IRequestHandler<GetHouseListQuery,HouseListVm>
    {
        private readonly IDiplomaDbContext _dbContext;
        public GetHouseListQueryHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HouseListVm> Handle (GetHouseListQuery request, CancellationToken cancellationToken)
        {
            var houses = _dbContext.Houses;
            var houseList = new HouseListVm
            {
                Houses = await houses.Select(x => new HouseListDto
                {
                    Desciption = x.Desciption.Substring(0, 100),
                    Floors = x.Floors,
                    Name = x.Name,
                    Photos = x.Photos,
                    Id = x.Id,
                    Preview = x.Preview,
                    Size = x.Size,
                    Square = x.Square
                }).ToListAsync(cancellationToken)
            };
            return houseList;
        }
    }
}
