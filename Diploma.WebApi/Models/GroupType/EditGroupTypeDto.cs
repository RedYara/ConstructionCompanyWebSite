using AutoMapper;
using Diploma.Application.Common.Mappings;
using Diploma.Application.CQRS.Commands.GroupType.CreateGroupType;

namespace Diploma.WebApi.Models.GroupType
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
