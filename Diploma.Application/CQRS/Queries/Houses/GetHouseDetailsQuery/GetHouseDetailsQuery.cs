using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.Houses.GetHouseDetailsQuery
{
    public class GetHouseDetailsQuery : IRequest<HouseDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
