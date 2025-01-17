﻿using MediatR;

namespace Application.CQRS.Queries.Products.GetProductDetailsQuery
{
    public class GetProductDetailsQuery : IRequest<ProductDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
