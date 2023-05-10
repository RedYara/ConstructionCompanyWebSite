using Diploma.Application.CQRS.Queries.Baths.GetBathDetailsQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.Houses.GetHouseDetailsQuery
{
    public class GetBathDetailsQuery : IRequest<BathDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
