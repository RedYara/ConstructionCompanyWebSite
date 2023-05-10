using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.BathsAndHouses
{
    public class BathsAndHousesVm
    {
        public BathsAndHousesVm() { BathsAndHouses = new List<BathsAndHousesDto>(); }
        public List<BathsAndHousesDto> BathsAndHouses { get; set; }
    }
}
