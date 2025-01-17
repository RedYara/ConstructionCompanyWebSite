using MediatR;

namespace Application.CQRS.Queries.GroupTypes.GetGroupTypeDetailsQuery
{
    public class GetGroupTypeDetailsQuery : IRequest<GroupTypeDetailsVm>
    {
        public int Id { get; set; }
    }
}
