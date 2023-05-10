using Diploma.Application.CQRS.Queries.Baths.GetBathListQuery;
using Diploma.Application.CQRS.Queries.Houses.GetHouseListQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.Baths.GetBathList
{
    public class GetBathListQuery : IRequest<BathListVm>
    {
    }
}
