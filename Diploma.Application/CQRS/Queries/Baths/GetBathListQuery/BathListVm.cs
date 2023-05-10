using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.Baths.GetBathListQuery
{
    public class BathListVm
    {
        public BathListVm() { Baths = new List<BathListDto>(); }
        public List<BathListDto> Baths { get; set; }
    }
}
