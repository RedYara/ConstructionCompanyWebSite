using Diploma.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.GroupTypes.GetGroupTypeListQuery
{
    public class GetGroupTypesListQueryHandler : IRequestHandler<GetGroupTypesListQuery, GroupTypeListVm>
    {
        private readonly IDiplomaDbContext _dbContext;
        public GetGroupTypesListQueryHandler(IDiplomaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<GroupTypeListVm> Handle(GetGroupTypesListQuery request, CancellationToken cancellationToken)
        {
            var groupTypes = _dbContext.GroupTypes;
            var groupTypeList = new GroupTypeListVm()
            {
                GroupTypeList = groupTypes.Select(x => new GroupTypeListDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList()
            };
            return groupTypeList;
        }

    }
}

