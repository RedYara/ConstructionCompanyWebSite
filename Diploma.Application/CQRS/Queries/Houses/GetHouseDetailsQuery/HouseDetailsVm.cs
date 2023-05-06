using Diploma.Application.Common.Mappings;
using Diploma.Domain;

namespace Diploma.Application.CQRS.Queries.Houses.GetHouseDetailsQuery
{
    public class HouseDetailsVm : IMapWith<House>
    {
        public House House { get; set; }
    }
}
