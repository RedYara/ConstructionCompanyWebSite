using AutoMapper;
using Diploma.Application.Common.Mappings;
using Diploma.Application.CQRS.Commands.GroupType.CreateGroupType;

namespace Diploma.WebApi.Models.GroupType
{
    public class CreateGroupTypeDto : IMapWith<CreateGroupTypeDto>
    {
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGroupTypeDto, CreateGroupTypeCommand>()
                .ForMember(command => command.Name,
                opt => opt.MapFrom(dto => dto.Name));
        }
    }
}
