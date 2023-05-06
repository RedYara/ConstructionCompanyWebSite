using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.Houses.GetHouseListQuery
{
    public class HouseListVm
    {
        public HouseListVm() { Houses = new List<HouseListDto>(); }
        public List<HouseListDto> Houses { get; set; }
    }
}
