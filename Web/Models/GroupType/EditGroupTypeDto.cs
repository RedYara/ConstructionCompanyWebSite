using Application.Common.Mappings;
using Application.CQRS.Commands.GroupType.CreateGroupType;
using AutoMapper;

namespace Web.Models.GroupType
{
    public class EditGroupTypeDto : IMapWith<EditGroupTypeDto>
    {
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditGroupTypeDto, EditGroupTypeCommand>()
                .ForMember(command => command.Name,
                opt => opt.MapFrom(dto => dto.Name));
        }
    }
}
