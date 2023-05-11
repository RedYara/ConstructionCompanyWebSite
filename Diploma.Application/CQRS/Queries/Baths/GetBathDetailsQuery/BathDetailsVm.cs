using AutoMapper;
using Diploma.Application.Common.Mappings;
using Diploma.Domain;

namespace Diploma.Application.CQRS.Queries.Baths.GetBathDetailsQuery
{
    public class BathDetailsVm : IMapWith<Bath>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Photos { get; set; }
        public string Preview { get; set; }
        public string Desciption { get; set; }
        public string Square { get; set; }
        public string Size { get; set; }
        public int Floors { get; set; }
        public List<Comment> Comments { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Bath, BathDetailsVm>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(order => order.Id))
                .ForMember(x => x.Name,
                opt => opt.MapFrom(order => order.Name))
                .ForMember(x => x.Photos,
                opt => opt.MapFrom(order => order.Photos))
                .ForMember(x => x.Preview,
                opt => opt.MapFrom(order => order.Preview))
                .ForMember(x => x.Desciption,
                opt => opt.MapFrom(order => order.Desciption))
                .ForMember(x => x.Square,
                opt => opt.MapFrom(order => order.Square))
                .ForMember(x => x.Size,
                opt => opt.MapFrom(order => order.Size))
                .ForMember(x => x.Floors,
                opt => opt.MapFrom(order => order.Floors))
                .ForMember(x => x.Comments,
                opt => opt.MapFrom(order => order.Comments));
        }
    }
}
