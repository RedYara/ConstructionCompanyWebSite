using AutoMapper;
using Diploma.Application.Common.Mappings;
using Diploma.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Application.CQRS.Queries.Products.GetProductDetailsQuery
{
    public class ProductDetailsVm : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Preview { get; set; }
        public string Description { get; set; }
        public int GroupTypeId { get; set; }
        public int Price { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailsVm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(product => product.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(product => product.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(product => product.Description))
                .ForMember(x => x.Price, opt => opt.MapFrom(product => product.Price))
                .ForMember(x => x.Comments, opt => opt.MapFrom(product => product.Comments))
                .ForMember(x => x.GroupTypeId, opt => opt.MapFrom(product => product.GroupType.Id));
        }
    }
}
