using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.Buildings.GetBuildingsListQuery
{
    public class GetBuildingsListQuery : IRequest<BuildingListVm>
    {
    }
}
