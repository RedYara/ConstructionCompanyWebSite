using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.CQRS.Commands.Product.EditProduct
{
    public class EditProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IFormFile Preview { get; set; }
        public string Description { get; set; }
        public int GroupTypeId { get; set; }
        public int Price { get; set; }
    }
}
