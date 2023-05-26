using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.GroupTypes.GetGroupTypeDetailsQuery
{
    public class GetGroupTypeDetailsQuery : IRequest<GroupTypeDetailsVm>
    {
        public int Id { get; set; }
    }
}
