using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.Order.ChangeOrderStatus
{
    public class ChangeOrderStatusCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
