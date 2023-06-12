using MediatR;
using Microsoft.AspNetCore.Http;

namespace Diploma.Application.CQRS.Commands.Product.CreateProduct
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public IFormFile Preview { get; set; }
        public string Description { get; set; }
        public int GroupTypeId { get; set; }
        public int Price { get; set; }
    }
}
