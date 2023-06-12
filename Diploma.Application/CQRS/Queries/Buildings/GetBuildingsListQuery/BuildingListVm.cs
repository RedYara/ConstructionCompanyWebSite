using Diploma.Domain;

namespace Diploma.Application.CQRS.Queries.Buildings.GetBuildingsListQuery
{
    public class BuildingListVm
    {
        public BuildingListVm() { Buildings = new List<BuildingListDto>(); Reviews = new List<Review>(); }
        public List<BuildingListDto> Buildings { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
