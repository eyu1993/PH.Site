using AutoMapper;
using PH.Site.Entity;
using PH.Site.WebAPI.Models;
using System;

namespace PH.Site.WebAPI.Mapper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<AppDTO, App>()
                .ForMember(o => o.Id, opt => opt.MapFrom(s => Guid.NewGuid()))
                .ForMember(o => o.Name, opt => opt.MapFrom(s => s.AppName));

            CreateMap<App, AppDTO>()
                .ForMember(o => o.AppName, opt => opt.MapFrom(s => s.Name));
        }
    }
}
