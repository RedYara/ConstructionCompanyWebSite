using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.GetOrderListQuery
{
    public class GetOrderListQuery : IRequest<OrderListVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
