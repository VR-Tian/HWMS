using System;
using AutoMapper;
using HWMS.Application.ViewModels;
using HWMS.DoMain.Models;
using HWMS.DoMain.Models.Access;

namespace HWMS.Application.AutoMapper
{
    /// <summary>
    /// 领域模型转换视图模型的实体映射配置
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();

            CreateMap<Order, OrderViewModel>()
                .ForMember(d => d.County, o => o.MapFrom(s => s.Address.County))
                .ForMember(d => d.Province, o => o.MapFrom(s => s.Address.Province))
                .ForMember(d => d.City, o => o.MapFrom(s => s.Address.City))
                .ForMember(d => d.Street, o => o.MapFrom(s => s.Address.Street));
        }
    }
}