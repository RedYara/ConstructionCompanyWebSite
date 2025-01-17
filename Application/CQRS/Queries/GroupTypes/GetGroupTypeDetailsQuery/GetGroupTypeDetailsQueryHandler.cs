using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Queries.GroupTypes.GetGroupTypeDetailsQuery
{
    public class GetGroupTypeDetailsQueryHandler(IWebDbContext dbContext) : IRequestHandler<GetGroupTypeDetailsQuery, GroupTypeDetailsVm>
    {
        private readonly IWebDbContext _dbContext = dbContext;

        public async Task<GroupTypeDetailsVm> Handle(GetGroupTypeDetailsQuery request, CancellationToken cancellationToken) => await _dbContext.GroupTypes.Select(x => new GroupTypeDetailsVm { Id = x.Id, Name = x.Name }).Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

    }
}
