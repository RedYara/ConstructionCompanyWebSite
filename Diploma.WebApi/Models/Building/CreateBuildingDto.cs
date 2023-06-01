using AutoMapper;
using Diploma.Application.Common.Mappings;
using Diploma.Application.CQRS.Commands.Building.CreateBuilding;
using System.ComponentModel.DataAnnotations;

namespace Diploma.WebApi.Models.Building
{
    public class CreateBuildingDto : IMapWith<CreateBuildingDto>
    {
        [Required(ErrorMessage = "Введите название строения")]
        [RegularExpression(@"^[\sА-Яа-яЁёa-zA-Z$&+,:;=?@#|""«»'<>.-^*()%!_-]+$", ErrorMessage = "Введены недопустимые символы")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Выберите фотографии")]
        public List<IFormFile> Photos { get; set; }
        [Required(ErrorMessage = "Выберите превью")]
        public IFormFile Preview { get; set; }
        [Required(ErrorMessage = "Укажите описание")]
        [RegularExpression(@"^[\sА-Яа-яЁёa-zA-Z$&+,:;=?@#|""«»'<>.-^*()%!_-]+$", ErrorMessage = "Введены недопустимые символы")]
        public string Desciption { get; set; }
        [Required(ErrorMessage = "Введите площадь строения")]
        [RegularExpression(@"^[-+]?\d+(\.\d+)?$", ErrorMessage = "Можно вводить только числа")]
        public string Square { get; set; }
        [Required(ErrorMessage = "Введите размерность строения")]
        [RegularExpression(@"^\d+x\d+$", ErrorMessage = "Можно вводить только числа")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Введите количество этажей")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Можно вводить только числа")]
        public int Floors { get; set; }
        [Required(ErrorMessage = "Укажите тип")]
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
