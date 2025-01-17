using Application.Common.Mappings;
using Application.CQRS.Commands.Product.EditProduct;
using Application.CQRS.Queries.Products.GetProductDetailsQuery;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Product
{
    public class EditProductDto : IMapWith<EditProductDto>, IMapWith<ProductDetailsVm>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Введите название услуги")]
        [RegularExpression(@"^[\sА-Яа-яЁёa-zA-Z$&+,:;=?@#|""«»'<>.-^*()%!_-]+$", ErrorMessage = "Введены недопустимые символы")]
        public string Name { get; set; }
        public string Preview { get; set; }
        [Required(ErrorMessage = "Укажите описание услуги")]
        [RegularExpression(@"^[\sА-Яа-яЁёa-zA-Z$&+,:;=?@#|""«»'<>.-^*()%!_-]+$", ErrorMessage = "Введены недопустимые символы")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Введите цену услуги")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Укажите тип")]
        public int GroupTypeId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductDetailsVm, EditProductDto>()
                .ForMember(command => command.Id,
                opt => opt.MapFrom(dto => dto.Id))
                .ForMember(command => command.Preview,
                opt => opt.Ignore())
                .ForMember(command => command.Name,
                opt => opt.MapFrom(dto => dto.Name))
                .ForMember(command => command.Description,
                opt => opt.MapFrom(dto => dto.Description))
                .ForMember(command => command.Price,
                opt => opt.MapFrom(dto => dto.Price));

            profile.CreateMap<EditProductDto, EditProductCommand>()
                .ForMember(command => command.Id,
                opt => opt.MapFrom(dto => dto.Id))
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
