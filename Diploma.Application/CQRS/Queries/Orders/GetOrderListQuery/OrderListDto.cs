using AutoMapper;
using Diploma.Application.Common.Mappings;
using Diploma.Domain;

namespace Diploma.Application.CQRS.Queries.Orders.GetOrderListQuery
{
    public class OrderListDto : IMapWith<Order>
    {
        public int Id { get; set; }
        public Guid BuildingId { get; set; }
        public string BuildingType { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderListDto>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(order => order.Id))
                .ForMember(x => x.BuildingId,
                opt => opt.MapFrom(order => order.BuildingId))
                .ForMember(x => x.Name,
                opt => opt.MapFrom(order => order.Name))
                .ForMember(x => x.Phone,
                opt => opt.MapFrom(order => order.Phone))
                .ForMember(x => x.CreationDate,
                opt => opt.MapFrom(order => order.CreationDate))
                .ForMember(x => x.BuildingType,
                opt => opt.MapFrom(order => order.BuildingType))
                .ForMember(x => x.Email,
                opt => opt.MapFrom(order => order.Email))
                .ForMember(x => x.Status,
                opt => opt.MapFrom(order => order.Status));
        }
    }
}
