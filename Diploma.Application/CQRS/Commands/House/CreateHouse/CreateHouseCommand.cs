using MediatR;
using Microsoft.AspNetCore.Http;

namespace Diploma.Application.CQRS.Commands.House.CreateHouse
{
    public class CreateHouseCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public List<IFormFile> Photos { get; set; }
        public IFormFile Preview { get; set; }
        public string Desciption { get; set; }
        public string Square { get; set; }
        public string Size { get; set; }
        public int Floors { get; set; }
    }
}
