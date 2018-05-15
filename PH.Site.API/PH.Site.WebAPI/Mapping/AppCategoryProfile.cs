using AutoMapper;
using PH.Site.DTO;
using PH.Site.Model;
using System;

namespace PH.Site.WebAPI.Mapping
{
    public class AppCategoryProfile : Profile
    {
        public AppCategoryProfile()
        {
            //CreateMap<CategoryDTO, Category>()
            //   .ForMember(o => o.CategoryId, opt => opt.MapFrom(s => s.CategoryId))
            //   .ForMember(o => o.CreateDate, opt => opt.MapFrom(s => s.CreateDate ?? DateTime.Now))
            //   .ForMember(o => o.ModifyDate, opt => opt.MapFrom(s => s.ModifyDate ?? DateTime.Now));


            //CreateMap<Category, CategoryDTO>()
            //   .ForMember(o => o.CategoryId, opt => opt.MapFrom(s => s.CategoryId));

            CreateMap<AppCategoryDTO, AppCategory>()
                .ForMember(d => d.ModifyDate, opt => opt.MapFrom(s => DateTime.Now))
                .ForMember(d => d.CreateDate, opt => opt.MapFrom(s => DateTime.Now));
        }
    }
}
