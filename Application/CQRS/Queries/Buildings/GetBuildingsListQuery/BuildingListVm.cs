using Domain;

namespace Application.CQRS.Queries.Buildings.GetBuildingsListQuery
{
    public class BuildingListVm
    {
        public BuildingListVm() { Buildings = []; Reviews = []; }
        public List<BuildingListDto> Buildings { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
