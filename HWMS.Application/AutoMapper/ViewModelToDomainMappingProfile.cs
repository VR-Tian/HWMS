using System;
using AutoMapper;
using HWMS.Application.ViewModels;
using HWMS.DoMain.Commands.Order;
using HWMS.DoMain.Models;

namespace HWMS.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<OrderViewModel, Order>()
            .ForPath(d => d.Address.City, o => o.MapFrom(s => s.City))
            .ForPath(d => d.Address.Province, o => o.MapFrom(s => s.Province))
            .ForPath(d => d.Address.County, o => o.MapFrom(s => s.County))
            .ForPath(d => d.Address.Street, o => o.MapFrom(s => s.Street));


            
             CreateMap<OrderViewModel, RegisterOrderCommand>()
             .ConstructUsing(c => new RegisterOrderCommand(c.OrderNumber));
        }
    }
}