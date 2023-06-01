using AutoMapper;
using Diploma.Application.Common.Mappings;
using Diploma.Application.CQRS.Commands.Product.CreateProduct;
using Diploma.WebApi.Models.Building;
using System.ComponentModel.DataAnnotations;

namespace Diploma.WebApi.Models.Product
{
    public class CreateProductDto : IMapWith<CreateProductDto>
    {
        [Required(ErrorMessage = "Введите название товара")]
        [RegularExpression(@"^[\sА-Яа-яЁёa-zA-Z$&+,:;=?@#|""«»'<>.-^*()%!_-]+$", ErrorMessage = "Введены недопустимые символы")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Выберите превью")]
        public IFormFile Preview { get; set; }
        [Required(ErrorMessage = "Укажите описание")]
        [RegularExpression(@"^[\sА-Яа-яЁёa-zA-Z$&+,:;=?@#|""«»'<>.-^*()%!_-]+$", ErrorMessage = "Введены недопустимые символы")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Введите цену товара")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Можно вводить только числа")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Укажите тип")]
        public int GroupTypeId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, CreateProductCommand>()
                .ForMember(command => command.Name,
                opt => opt.MapFrom(dto => dto.Name))
                .ForMember(command => command.Preview,
                opt => opt.MapFrom(dto => dto.Preview))
                .ForMember(command => command.Description,
                opt => opt.MapFrom(dto => dto.Description))
                .ForMember(command => command.Price,
                opt => opt.MapFrom(dto => dto.Price))
                .ForMember(command => command.GroupTypeId,
                opt => opt.MapFrom(dto => dto.GroupTypeId));
        }
    }
}
