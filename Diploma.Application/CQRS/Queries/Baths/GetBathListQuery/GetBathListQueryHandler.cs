using Diploma.Application.CQRS.Queries.Baths.GetBathListQuery;
using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Application.CQRS.Queries.Baths.GetBathList
{
    public class GetBathListQueryHandler : IRequestHandler<GetBathListQuery, BathListVm>
    {
        private readonly IDiplomaDbContext _dbContext;
        public GetBathListQueryHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BathListVm> Handle(GetBathListQuery request, CancellationToken cancellationToken)
        {
            var baths = _dbContext.Baths;
            var bathList = new BathListVm()
            {
                Baths = await baths.Select(x => new BathListDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Desciption = x.Desciption,
                    Floors = x.Floors,
                    Preview = x.Preview,
                    Size = x.Size,
                    Square = x.Square
                }).ToListAsync()
            };
            return bathList;
        }
    }
}
