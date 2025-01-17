using MediatR;

namespace Application.CQRS.Queries.Buildings.GetBuildingsListQuery
{
    public class GetBuildingsListQuery : IRequest<BuildingListVm>
    {
    }
}
