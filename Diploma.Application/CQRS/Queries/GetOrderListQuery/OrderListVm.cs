using AutoMapper;
using Diploma.Application.Common.Mappings;
using Diploma.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.GetOrderListQuery
{
    public class OrderListVm : IMapWith<Order>
    {
        public IList<OrderListDto> Orders { get; set; }
    }
}
