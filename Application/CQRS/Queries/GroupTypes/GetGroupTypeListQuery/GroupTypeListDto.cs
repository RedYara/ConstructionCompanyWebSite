using Application.Common.Mappings;
using Domain;

namespace Application.CQRS.Queries.GroupTypes.GetGroupTypeListQuery
{
    public class GroupTypeListDto : IMapWith<GroupType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
