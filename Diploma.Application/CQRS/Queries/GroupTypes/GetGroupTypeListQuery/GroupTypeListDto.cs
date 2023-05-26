using Diploma.Application.Common.Mappings;
using Diploma.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.GroupTypes.GetGroupTypeListQuery
{
    public class GroupTypeListDto : IMapWith<GroupType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
