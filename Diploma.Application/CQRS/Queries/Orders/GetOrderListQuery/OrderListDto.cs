using AutoMapper;
using Diploma.Application.Common.Mappings;
using Diploma.Domain;

namespace Diploma.Application.CQRS.Queries.Orders.GetOrderListQuery
{
    public class OrderListDto : IMapWith<Order>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderListDto>()
                .ForMember(x => x.Title,
                opt => opt.MapFrom(order => order.Title))
                .ForMember(x => x.Description,
                opt => opt.MapFrom(order => order.Description))
                .ForMember(x => x.CreationDate,
                opt => opt.MapFrom(order => order.CreationDate));
        }
    }
}
