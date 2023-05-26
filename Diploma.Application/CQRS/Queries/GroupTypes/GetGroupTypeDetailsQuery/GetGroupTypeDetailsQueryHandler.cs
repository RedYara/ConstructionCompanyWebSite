using Diploma.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.GroupTypes.GetGroupTypeDetailsQuery
{
    public class GetGroupTypeDetailsQueryHandler : IRequestHandler<GetGroupTypeDetailsQuery, GroupTypeDetailsVm>
    {
        private readonly IDiplomaDbContext _dbContext;
        public GetGroupTypeDetailsQueryHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<GroupTypeDetailsVm> Handle(GetGroupTypeDetailsQuery request, CancellationToken cancellationToken) => await _dbContext.GroupTypes.Select(x => new GroupTypeDetailsVm { Id = x.Id, Name = x.Name }).Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

    }
}
