using System;
using AutoMapper;
using HWMS.Application.ViewModels;
using HWMS.DoMain.Models;

namespace HWMS.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                //领域模型 -> 视图模型的映射，是 读命令
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                //视图模型 -> 领域模式的映射，是 写 命令
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}