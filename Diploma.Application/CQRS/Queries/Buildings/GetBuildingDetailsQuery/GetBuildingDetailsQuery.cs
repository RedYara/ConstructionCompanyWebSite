using MediatR;

namespace Diploma.Application.CQRS.Queries.Buildings.GetBuildingDetailsQuery
{
    public class GetBuildingDetailsQuery : IRequest<BuildingDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
