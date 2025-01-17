using Application.Common.Mappings;
using Domain;

namespace Application.CQRS.Queries.Orders.GetOrderListQuery
{
    public class OrderListVm : IMapWith<Order>
    {
        public IList<OrderListDto> Orders { get; set; }
    }
}
