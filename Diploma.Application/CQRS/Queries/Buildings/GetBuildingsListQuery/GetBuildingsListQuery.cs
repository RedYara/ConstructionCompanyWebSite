using MediatR;

namespace Diploma.Application.CQRS.Queries.Buildings.GetBuildingsListQuery
{
    public class GetBuildingsListQuery : IRequest<BuildingListVm>
    {
    }
}
