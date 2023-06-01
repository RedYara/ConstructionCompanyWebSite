using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Commands.Product.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
