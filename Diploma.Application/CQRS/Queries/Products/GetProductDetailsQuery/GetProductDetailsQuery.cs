using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.Products.GetProductDetailsQuery
{
    public class GetProductDetailsQuery : IRequest<ProductDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
