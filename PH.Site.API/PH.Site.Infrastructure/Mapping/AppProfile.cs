using AutoMapper;
using PH.Site.DTO;
using PH.Site.Model;

namespace PH.Site.Infrastructure.Mapping
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<AppDTO, App>()
                .ForMember(o => o.Id, opt => opt.MapFrom(s => s.AppId))
                .ForMember(o => o.Name, opt => opt.MapFrom(s => s.AppName));

            CreateMap<App, AppDTO>()
                .ForMember(o => o.AppName, opt => opt.MapFrom(s => s.Name))
                .ForMember(o => o.AppId, opt => opt.MapFrom(s => s.Id));
        }
    }
}
