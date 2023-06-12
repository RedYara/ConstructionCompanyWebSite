using MediatR;

namespace Diploma.Application.CQRS.Queries.GroupTypes.GetGroupTypeListQuery
{
    public class GetGroupTypesListQuery : IRequest<GroupTypeListVm>
    {
    }
}
