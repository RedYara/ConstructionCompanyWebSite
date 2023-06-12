using Diploma.Application.Common.Mappings;
using Diploma.Domain;

namespace Diploma.Application.CQRS.Queries.Buildings.GetBuildingsListQuery
{
    public class BuildingListDto : IMapWith<Building>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Photos { get; set; }
        public string Preview { get; set; }
        public string Desciption { get; set; }
        public string Square { get; set; }
        public GroupType GroupType { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string Size { get; set; }
        public int Floors { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
