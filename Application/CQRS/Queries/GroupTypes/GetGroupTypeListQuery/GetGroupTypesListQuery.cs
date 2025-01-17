using MediatR;

namespace Application.CQRS.Queries.GroupTypes.GetGroupTypeListQuery
{
    public class GetGroupTypesListQuery : IRequest<GroupTypeListVm>
    {
    }
}
