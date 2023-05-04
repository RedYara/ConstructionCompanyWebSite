using Diploma.Application.Common.Mappings;
using Diploma.Domain;

namespace Diploma.Application.CQRS.Queries.GetOrderListQuery
{
    public class OrderListVm : IMapWith<Order>
    {
        public IList<OrderListDto> Orders { get; set; }
    }
}
