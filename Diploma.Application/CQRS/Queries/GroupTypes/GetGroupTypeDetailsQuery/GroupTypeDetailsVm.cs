using AutoMapper;
using Diploma.Application.Common.Mappings;
using Diploma.Domain;

namespace Diploma.Application.CQRS.Queries.GroupTypes.GetGroupTypeDetailsQuery
{
    public class GroupTypeDetailsVm : IMapWith<GroupType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GroupType, GroupTypeDetailsVm>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(order => order.Id))
                .ForMember(x => x.Name,
                opt => opt.MapFrom(order => order.Name));
        }
    }
}
