using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.CQRS.Commands.Building.CreateBuilding
{
    public class CreateBuildingCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public List<IFormFile> Photos { get; set; }
        public IFormFile Preview { get; set; }
        public string Desciption { get; set; }
        public string Square { get; set; }
        public string Size { get; set; }
        public int Floors { get; set; }
        public int GroupTypeId { get; set; }
    }
}
