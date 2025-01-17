using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Queries.GroupTypes.GetGroupTypeListQuery
{
    public class GetGroupTypesListQueryHandler(IWebDbContext dbContext) : IRequestHandler<GetGroupTypesListQuery, GroupTypeListVm>
    {
        private readonly IWebDbContext _dbContext = dbContext;

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

