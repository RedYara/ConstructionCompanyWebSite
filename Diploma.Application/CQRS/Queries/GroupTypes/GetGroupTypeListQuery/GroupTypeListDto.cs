using Diploma.Application.Common.Mappings;
using Diploma.Domain;

namespace Diploma.Application.CQRS.Queries.GroupTypes.GetGroupTypeListQuery
{
    public class GroupTypeListDto : IMapWith<GroupType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
