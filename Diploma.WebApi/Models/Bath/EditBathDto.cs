﻿using AutoMapper;
using Diploma.Application.CQRS.Queries.Baths.GetBathDetailsQuery;

namespace Diploma.WebApi.Models.Bath
{
    public class EditBathDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Photos { get; set; }
        public string Preview { get; set; }
        public string Desciption { get; set; }
        public string Square { get; set; }
        public string Size { get; set; }
        public int Floors { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BathDetailsVm, EditBathDto>()
                .ForMember(command => command.Photos,
                opt => opt.MapFrom(dto => dto.Photos))
                .ForMember(command => command.Id,
                opt => opt.MapFrom(dto => dto.Id))
                .ForMember(command => command.Name,
                opt => opt.MapFrom(dto => dto.Name))
                .ForMember(command => command.Preview,
                opt => opt.MapFrom(dto => dto.Preview))
                .ForMember(command => command.Desciption,
                opt => opt.MapFrom(dto => dto.Desciption))
                .ForMember(command => command.Size,
                opt => opt.MapFrom(dto => dto.Size))
                .ForMember(command => command.Square,
                opt => opt.MapFrom(dto => dto.Square))
                .ForMember(command => command.Floors,
                opt => opt.MapFrom(dto => dto.Floors));

            profile.CreateMap<EditBathDto, EditBathDto>()
                .ForMember(command => command.Photos,
                opt => opt.MapFrom(dto => dto.Photos))
                .ForMember(command => command.Id,
                opt => opt.MapFrom(dto => dto.Id))
                .ForMember(command => command.Name,
                opt => opt.MapFrom(dto => dto.Name))
                .ForMember(command => command.Preview,
                opt => opt.MapFrom(dto => dto.Preview))
                .ForMember(command => command.Desciption,
                opt => opt.MapFrom(dto => dto.Desciption))
                .ForMember(command => command.Size,
                opt => opt.MapFrom(dto => dto.Size))
                .ForMember(command => command.Square,
                opt => opt.MapFrom(dto => dto.Square))
                .ForMember(command => command.Floors,
                opt => opt.MapFrom(dto => dto.Floors));
        }
    }
}
