using AutoMapper;
using Diploma.Application.Common.Mappings;
using Diploma.Application.CQRS.Commands.Building.CreateBuilding;

namespace Diploma.WebApi.Models.Building
{
    public class CreateBuildingDto : IMapWith<CreateBuildingDto>
    {
        public string Name { get; set; }
        public List<IFormFile> Photos { get; set; }
        public IFormFile Preview { get; set; }
        public string Desciption { get; set; }
        public string Square { get; set; }
        public string Size { get; set; }
        public int Floors { get; set; }
        public int GroupTypeId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBuildingDto, CreateBuildingCommand>()
                .ForMember(command => command.Photos,
                opt => opt.MapFrom(dto => dto.Photos))
                .ForMember(command => command.Name,
                opt => opt.MapFrom(dto => dto.Name))
                .ForMember(command => command.Preview,
                opt => opt.MapFrom(dto => dto.Preview))
                .ForMember(command => command.Desciption,
                opt => opt.MapFrom(dto => dto.Desciption))
                .ForMember(command => command.Size,
                opt => opt.MapFrom(dto => dto.Size))
                .ForMember(command => command.Square,
                opt => opt.MapFrom(dto => dto.Square))
                .ForMember(command => command.Floors,
                opt => opt.MapFrom(dto => dto.Floors))
                .ForMember(command => command.GroupTypeId,
                opt => opt.MapFrom(dto => dto.GroupTypeId));
        }
    }

}
