using System;
using AutoMapper;
using HWMS.Application.ViewModels;
using HWMS.DoMain.Models;

namespace HWMS.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Order, OrderViewModel>();
        }
    }
}