﻿using AutoMapper;
using Application.Common.Mappings;
using Domain;

namespace Application.CQRS.Queries.Buildings.GetBuildingDetailsQuery
{
    public class BuildingDetailsVm : IMapWith<Building>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Photos { get; set; }
        public string Preview { get; set; }
        public string Desciption { get; set; }
        public string Square { get; set; }
        public string Size { get; set; }
        public int Floors { get; set; }
        public int GroupTypeId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Building, BuildingDetailsVm>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(order => order.Id))
                .ForMember(x => x.Name,
                opt => opt.MapFrom(order => order.Name))
                .ForMember(x => x.Desciption,
                opt => opt.MapFrom(order => order.Desciption))
                .ForMember(x => x.Square,
                opt => opt.MapFrom(order => order.Square))
                .ForMember(x => x.Size,
                opt => opt.MapFrom(order => order.Size))
                .ForMember(x => x.Floors,
                opt => opt.MapFrom(order => order.Floors))
                .ForMember(x => x.Comments,
                opt => opt.MapFrom(order => order.Comments))
                .ForMember(x => x.GroupTypeId,
                opt => opt.MapFrom(order => order.GroupType.Id));
        }
    }
}
