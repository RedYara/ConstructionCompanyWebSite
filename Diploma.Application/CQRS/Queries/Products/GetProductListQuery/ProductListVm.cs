using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.Products.GetProductListQuery
{
    public class ProductListVm
    {
        public ProductListVm()
        {
            Products = new List<ProductListDto>();
        }

        public List<ProductListDto> Products { get; set; }
    }
}
