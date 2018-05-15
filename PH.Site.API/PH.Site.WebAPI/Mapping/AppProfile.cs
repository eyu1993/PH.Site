using AutoMapper;
using PH.Site.DTO;
using PH.Site.Model;

namespace PH.Site.WebAPI.Mapping
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<AppDTO, App>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.AppId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.AppName));

            CreateMap<App, AppDTO>()
                .ForMember(d => d.AppName, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.AppId, opt => opt.MapFrom(s => s.Id));
        }
    }
}
