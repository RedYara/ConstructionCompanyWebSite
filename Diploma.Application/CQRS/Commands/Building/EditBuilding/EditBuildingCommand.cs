using MediatR;
using Microsoft.AspNetCore.Http;


namespace Diploma.Application.CQRS.Commands.Building.EditBuilding
{
    public class EditBuildingCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
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
