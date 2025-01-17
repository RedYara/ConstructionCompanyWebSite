using MediatR;

namespace Application.CQRS.Queries.Buildings.GetBuildingDetailsQuery
{
    public class GetBuildingDetailsQuery : IRequest<BuildingDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
