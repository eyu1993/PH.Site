using AutoMapper;
using PH.Site.DTO;
using PH.Site.Model;
using System;

namespace PH.Site.Infrastructure.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO, AppCategory>()
               .ForMember(o => o.CategoryId, opt => opt.MapFrom(s => s.CategoryId))
               .ForMember(o => o.CreateDate, opt => opt.MapFrom(s => s.CreateDate ?? DateTime.Now))
               .ForMember(o => o.ModifyDate, opt => opt.MapFrom(s => s.ModifyDate ?? DateTime.Now));


            CreateMap<AppCategory, CategoryDTO>()
               .ForMember(o => o.CategoryId, opt => opt.MapFrom(s => s.CategoryId));
        }
    }
}
